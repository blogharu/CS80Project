import csv
import numpy as np
import math
import random
import sys
import os
from scipy.optimize import minimize
import mathFunctions as mf

# Read Arguments
csvFile = open(os.getcwd()+"\\arguments.csv")
csvReader = csv.reader(csvFile, delimiter=',')
arguments=[]
for row in csvReader:
    arguments.append(row)

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
dicCheckIsVariableInConstraints = {}

# Fill in the listSamples and listResults
numVariables = int(arguments[1][0])
numConstraints = int(arguments[1][1])
for i in range(numVariables):
    variablesDicID[arguments[2+i][0]] = variableID
    dicCheckIsVariableInConstraints[arguments[2+i][0]] = 0
    variablesListBound.append((float(arguments[2+i][1]),float(arguments[2+i][2])))
    variablesDicType[arguments[2+i][0]] = int(arguments[2+i][3])
    variableID += 1
for i in range(numConstraints):
    constraintsList.append(mf.removeEqaulSign(mf.removeSpaceFromString(arguments[numVariables + i + 2][0])));
    tempDic = mf.countNumVariablesInEquation(mf.removeSpaceFromString(arguments[numVariables + i + 2][0]),variablesDicID)
    for key in tempDic.keys():
        dicCheckIsVariableInConstraints[key] += tempDic[key]

# Set initial point where the program starts optimize.
opInitial = []
for var in variablesDicID.keys():
    ran = mf.getRandomNumber(variablesListBound[variablesDicID[var]])
    if variablesDicType[var] == 1:
        opInitial.append(round(ran,0))
        constraintsList.append([0,var+"-("+str(round(ran,0))+")"])
    else:
        opInitial.append(ran)
        if dicCheckIsVariableInConstraints[var] <= 0:
            constraintsList.append([0,var+"-("+str(ran)+")"])

# Set the function that the program will optimize.
opObjFun = mf.getObjectiveFunctionForRandomGeneration(opInitial) ########### This is for maximize the result!
opConsList = mf.getConstraintsForOptimization(constraintsList,variablesDicID)

# Set the boundary of each variable.
opBound = tuple(variablesListBound)

# Start optimization.
sol = minimize(opObjFun,opInitial,method='SLSQP',bounds=opBound,constraints=opConsList)

# Return the result.
if sol.success:
    print(mf.optimizationResultNPArrayToCSVString(sol.x), file=sys.stdout)
else:
    print("false", file=sys.stderr)
