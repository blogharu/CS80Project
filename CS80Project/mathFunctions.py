import math
import numpy as np
import random

# Regression

# Get c vector that makes listSamples dot c = listResults smallest. 

def leastSquare(listSamples, listResults, numVariables):
    # Change the listSamples and listResults to matrix
    matrixSamples = np.matrix(listSamples)
    matrixResults = np.matrix(listResults)

    # Calculate the regression and get C vector
    XTX = matrixSamples.T*matrixSamples
    XTY = matrixSamples.T*matrixResults
    C = XTX.I*XTY

    # Get the minimum and maximum value of C
    #minC = C[numVariables-1][0]
    #maxC = C[numVariables-1][0]
    #for i in range(numVariables-1):
    #    if minC > C[i][0]:
    #        minC = C[i][0]
    #    if maxC < C[i][0]:
    #        maxC = C[i][0]

    # Normalize vector C
    #C = (C-minC)/(maxC-minC)
    return C


# Helping functions

#####################

def optimizationResultNPArrayToCSVString(result):
    return removeSpaceFromString(np.array2string(result, precision=2, separator=',',suppress_small=True))[1:-1]

# Check if the given string is number or not.

def isNumber(str):
    try:
        float(str)
        return True
    except:
        return False

# Remove space from given string.
    
def removeSpaceFromString(str):
    temp = ""
    for char in str:
        if char != ' ':
            temp = temp + char
    return temp

# Change equation string or inequality string to below list.
#   input        output
# f(X) = Y  -> [0, f(X)-(Y)]
# f(X) > Y  -> [1, f(X)-(Y)]
# f(X) >= Y -> [1, f(X)-(Y)]
# f(X) < Y  -> [1, Y-(f(X))]
# f(X) <= Y -> [1, Y-(f(X))]
# The first element is the type of the equation and second element is eqaution for optimization.

def removeEqaulSign(equation):
    type = 0
    temp = ""
    result = ""
    for char in equation:
        if char == '>':
            result = temp + "-"
            type = 1
            temp = ""
        elif char == '<':
            result = "-(" + temp + ")+"
            type = 1
            temp = ""
        elif char == '=':
            if type == 0:
                result = temp + "-"
                temp = ""
        else:
            temp = temp + char
    result = result + "(" + temp + ")"
    return [type, result]

# From the given string equation, find the variables in varDicID.

def countNumVariablesInEquation (equation, varDicID):
    countDic = {}
    for key in varDicID.keys():
        countDic[key] = 0
    temp = ""
    for char in equation:
        if char == '+' or char == '-' or char == '*' or char == '/' or char == '^' or char == '(' or char == ')':
            if temp != "":
                if temp in varDicID.keys():
                    countDic[temp] += 1
                temp = ""
        else:
            temp = temp + char
    return countDic


# Calculate the equation string.
def calculateEquationReturnString(x, equation, varDic):
    temp = ""
    temp = removeParenthesis(x, equation, varDic)
    temp = removeMath(x, temp, varDic)
    #temp = removePower(x, temp, varDic) # THIS FUNCTION IS NOT READY YET.
    temp = removeVariablesFromString(x, temp, varDic)
    return str(eval(temp))

# This is for debuging calculateEquationReturnString function.
printCalculationSteps = 0

# This function is part of the calculateEquationReturnString function.
# It remove the parenthesis from equation string.
def removeParenthesis(x, equation, varDic):
    temp = ""
    result = ""
    numLeftParenthesis = 0
    if printCalculationSteps == 1:
        print("removeParenthesis!")
        print(equation)
    for char in equation:
        if char == '(':
            if numLeftParenthesis == 0:
                result = result + temp
                temp = ""
            else:
                temp = temp + char
            numLeftParenthesis += 1
        elif char == ')':
            numLeftParenthesis -= 1
            if numLeftParenthesis == 0:
                result = result + calculateEquationReturnString(x, temp, varDic)
                temp = ""
            else:
                temp = temp + char
        else:
            temp = temp + char
    result = result + temp
    return result

# This function is part of the calculateEquationReturnString function.
# From simpleEquation, find math.sin and math.cos string and change it to number.
def removeMath(x, simpleEquation, varDic):
    temp = ""
    arg = ""
    equation = simpleEquation
    if printCalculationSteps == 1:
        print("removeMath!")
        print(equation)
    while equation.find('math.sin') != -1:
        temp = equation[equation.find('math.sin') + 8:-1]
        equation = equation[0:equation.find('math.sin')]
        check = 0
        for char in temp:
            if char == '+' or char == '-' or char == '*' or char == '/' or char == '^':
                arg = temp[0:temp.find(char)]
                equation = equation + str(math.sin(float(arg)*math.pi/180)) + temp[temp.find(char):-1]
                check = 1
                break
        if check == 0:
            equation = equation + str(math.sin(float(temp)*math.pi/180))
    while equation.find('math.cos') != -1:
        temp = equation[equation.find('math.cos') + 8:-1]
        equation = equation[0:equation.find('math.cos')]
        check = 0
        for char in temp:
            if char == '+' or char == '-' or char == '*' or char == '/' or char == '^':
                arg = temp[0:temp.find(char)]
                equation = equation + str(math.cos(float(arg)*math.pi/180)) + temp[temp.find(char):-1]
                check = 1
                break
        if check == 0:
            equation = equation + str(math.cos(float(temp)*math.pi/180))
    return equation

##################################################
# This function is ready yet.
def removePower(x, equation, varDic):
    if printCalculationSteps == 1:
        print("removePower!")
        print(equation)
    return equation
##################################################

# This function is part of the calculateEquationReturnString function.
# Find the variable from simpleEquation and change it to the x[varID].
# It allow the program to calculate the equation like Xc = Y.
def removeVariablesFromString(x, simpleEquation, varDicID):
    temp = ""
    equation = ""
    mathCounter = 0
    if printCalculationSteps == 1:
        print("removeVariables!")
        print(simpleEquation)
    for char in simpleEquation:
        if char == '+' or char == '-' or char == '*' or char == '/' or char == '^':
            if temp == "":
                equation = equation + char
            else:
                if temp in varDicID.keys():
                    equation = equation + str(x[varDicID[temp]]) + char
                else:
                    equation = equation + temp + char
                temp = ""
        else:
            temp = temp + char
    if isNumber(temp):
        equation = equation + temp
    else:
        equation = equation + str(x[varDicID[temp]])
    return equation

# Optimization

# Get the random number X such that bound[0] <= X <= bound[1]+bound[0]
def getRandomNumber(bound):
    return bound[0] + (bound[1]-bound[0])*random.random()

# This function is generating objective function for random sample generation.
def getObjectiveFunctionForRandomGeneration(initial):
    def objective(x):
        result = 0
        for i in range(len(x)):
            result = result + (x[i]-initial[i])*(x[i]-initial[i])
        return result
    return objective

# This function is generating objective function for optimization.
def getObjectiveFunction(npMatrix):
    def objective(x):
        result = 0
        for i in range(npMatrix.size-1):
            result = result + npMatrix.item(i)*x[i]
        result = result + npMatrix.item(npMatrix.size-1)
        return result
    return objective

# This function is generating function that is used for optimization constraints.
def getConstraintFunction(constraintEquation,varDicID):
    def constraint(x):
        return float(calculateEquationReturnString(x,constraintEquation,varDicID))
    return constraint

# This function is generating list of functions that are used for optimization constraints.
def getConstraintsForOptimization(constraintsList, varDicID):
    result = []
    for constraint in constraintsList:
        if constraint[0] == 0:
            result.append({'type': 'eq', 'fun': getConstraintFunction(constraint[1],varDicID)})
        else:
            result.append({'type': 'ineq', 'fun': getConstraintFunction(constraint[1],varDicID)})
    return result
