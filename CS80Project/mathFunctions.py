import math
import numpy as np
import random

# Regression
def leastSquare(listSamples, listResults, numVariables):
    # Change the listSamples and listResults to matrix
    matrixSamples = np.matrix(listSamples)
    matrixResults = np.matrix(listResults)

    # Calculate the regression and get C vector
    XTX = matrixSamples.T*matrixSamples
    XTY = matrixSamples.T*matrixResults
    C = XTX.I*XTY

    # Get the minimum and maximum value of C
    minC = C[numVariables-1][0]
    maxC = C[numVariables-1][0]
    for i in range(numVariables-1):
        if minC > C[i][0]:
            minC = C[i][0]
        if maxC < C[i][0]:
            maxC = C[i][0]

    # Normalize vector C
    C = (C-minC)/(maxC-minC)
    return C


# Helping functions
def optimizationResultNPArrayToCSVString(result):
    return removeSpaceFromString(np.array2string(result, precision=2, separator=',',suppress_small=True))[1:-1]

def isNumber(str):
    try:
        float(str)
        return True
    except:
        return False

def removeSpaceFromString(str):
    temp = ""
    for char in str:
        if char != ' ':
            temp = temp + char
    return temp

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


# Analize Equation
def calculateEquationReturnString(x, equation, varDic):
    temp = ""
    temp = removeParenthesis(x, equation, varDic)
    #temp = removeMath(x, temp, varDic)
    #temp = removePower(x, temp, varDic)
    temp = removeVariablesFromString(x, temp, varDic)
    return str(eval(temp))

printCalculationSteps = 0

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
            numLeftParenthesis += 1
        elif char == ')':
            numLeftParenthesis -= 1
            if numLeftParenthesis == 0:
                result = result + calculateEquationReturnString(x, temp, varDic)
                temp = ""
        else:
            temp = temp + char
    result = result + temp
    return result

##################################################
def removeMath(x, equation, varDic):
    if printCalculationSteps == 1:
        print("removeMath!")
        print(equation)
    return equation
##################################################

##################################################
def removePower(x, equation, varDic):
    if printCalculationSteps == 1:
        print("removePower!")
        print(equation)
    return equation
##################################################

def removeVariablesFromString(x, simpleEquation, varDicID):
    temp = ""
    equation = ""
    mathCounter = 0
    if printCalculationSteps == 1:
        print("removeVariables!")
        print(equation)
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
def getRandomNumber(bound):
    return bound[0] + (bound[1]-bound[0])*random.random()


def getObjectiveFunctionForRandomGeneration(initial):
    def objective(x):
        result = 0
        for i in range(len(x)):
            result = result + (x[i]-initial[i])*(x[i]-initial[i])
        return result
    return objective

def getObjectiveFunction(npMatrix):
    def objective(x):
        result = 0
        for i in range(npMatrix.size-1):
            result = result + npMatrix.item(i)*x[i]
        result = result + npMatrix.item(npMatrix.size-1)
        return result
    return objective

def getConstraintFunction(constraintEquation,varDicID):
    def constraint(x):
        return float(calculateEquationReturnString(x,constraintEquation,varDicID))
    return constraint

def getConstraintsForOptimization(constraintsList, varDicID):
    result = []
    for constraint in constraintsList:
        if constraint[0] == 0:
            result.append({'type': 'eq', 'fun': getConstraintFunction(constraint[1],varDicID)})
        else:
            result.append({'type': 'ineq', 'fun': getConstraintFunction(constraint[1],varDicID)})
    return result
