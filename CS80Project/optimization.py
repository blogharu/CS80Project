import csv
import numpy as np
import math
from random import random
import sys
import os
from scipy.optimize import minimize
import mathFunctions as mf

# Get path of result file
csvFile = open(os.getcwd()+"\\arguments.csv")
csvReader = csv.reader(csvFile, delimiter=',')
arguments=[]
for row in csvReader:
    arguments.append(row[0])

# Read the Result.csv file
csvFile = open(arguments[1])################
csvReader = csv.reader(csvFile, delimiter=',')

# Set initial variables
lineCount = 0
numVariables = 0
variablesDicID = {}
variablesListBound = []
variablesDicType = {}
variableID = 0
numConstraints = 0
constraintsList = []
numSamples = 0
listSamples = []
listResults = []

# Fill in the listSamples and listResults
for row in csvReader:
    if lineCount == 0:
        lineCount = lineCount + 1
    elif lineCount == 1: # set num variables, constraints, and samples
        numVariables = int(row[0])
        numConstraints = int(row[1])
        numSamples = int(row[2])
        lineCount += 1
    elif lineCount == 2:
        lineCount += 1
    elif lineCount <= 2 + numVariables:
        variablesDicID[row[0]] = variableID
        variablesListBound.append((float(row[1]),float(row[2])))
        variablesDicType[row[0]] = int(row[3])
        variableID += 1
        lineCount += 1
    elif lineCount == 3 + numVariables:
        lineCount += 1
    elif lineCount <= 3 + numVariables + numConstraints:
        constraintsList.append(mf.removeEqaulSign(mf.removeSpaceFromString(row[0])));
        lineCount += 1
    elif lineCount == 4 + numVariables + numConstraints:
        lineCount += 1
    else:
        list = []
        for i in range(numVariables):
            list.append(float(row[i+1]))
        list.append(1.0)
        listSamples.append(list)
        list = []
        try:
            list.append(float(row[numVariables+1]))
        except:
            print("Fill in the result column.",file=sys.stderr)
            sys.exit()
        listResults.append(list)
        lineCount += 1

# Get regression lines coefficient

C = mf.leastSquare(listSamples, listResults, numVariables)

# Set optimization arguments
opInitial = []
for b in variablesListBound:
    opInitial.append(mf.getRandomNumber(b))
opObjFun = mf.getObjectiveFunction(C*-1) ########### This is for maximize the result!
#opObjFun = mf.getObjectiveFunction(C) ########### This is for minimize the result!
opConsList = mf.getConstraintsForOptimization(constraintsList,variablesDicID)
opBound = tuple(variablesListBound)

sol = minimize(opObjFun,opInitial,method='SLSQP',bounds=opBound,constraints=opConsList)

# Optimization
if sol.success:
    print(mf.optimizationResultNPArrayToCSVString(sol.x), file=sys.stdout)
else:
    print("false", file=sys.stderr)
