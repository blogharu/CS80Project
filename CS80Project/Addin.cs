///<summary>
///     File Name: Addin.cs
///     Description: Main SolidWorks add-on back-end
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CS80Project
{
    public class Addin : SwAddin
    {
        // If the system is in 32 bit, 
        // 1. Right click CS80Project
        // 2. Click properties
        // 3. Click the platform tab
        // 4. Change platform target to x86.
        //  - if system is in 64 bit, choose x64.

        #region constants
        public const string SWTASKPANE_PROGID = "SolidWorksProgID"; // SolidWorks Process ID
        public const int MAX_VARIABLE_NUM = 6; // Max limit on variable nuumber
        public const int MAX_CONSTRAINT_NUM = 6; // Max limit on constant number
        #endregion

        #region variables
        public static SldWorks swApp; // Main SolidWorks Process 
        public Variables variables;
        public Constraints constraints;

        int SessionCookie;
        private MainUI mMainUI;
        private TaskpaneView mTaskpaneView;
        public static string pythonLocation;

        #endregion

        #region Struct

        /// <summary>
        ///     Struct: Constraints Stuct handling
        ///     Description: Main Back-end for constraints handling on CAD objects
        /// </summary>
        public struct Constraints
        {
            public int numConstraints; // Number of active constraints
            public string[] constraintsName; // List of active constraints name
            public string[] constraintsEquation; // List of active constraints equation

            /// <summary>
            /// Function Name: addConstraint
            /// Description: Main back-end for adding constraints to the add-on 
            /// </summary>
            /// <param name="name">Name of the constraint to be added</param>
            /// <param name="equation">Equation of the constraint to be added</param>
            /// <returns>Error - 0, Success - 1</returns>
            public int addConstraint(string name, string equation)
            {
                // If Number of Constraints is at max number allowed => send error message to user
                if (numConstraints == MAX_CONSTRAINT_NUM)
                {
                    swApp.SendMsgToUser("You cannot have more than " + MAX_CONSTRAINT_NUM + " constraints!");
                    return 0; // Return error
                }

                // If constraints name list is empty => add first name
                if (constraintsName == null) { constraintsName = new string[MAX_CONSTRAINT_NUM]; }
                
                // If constraints equation list is empty => add first constraint
                if (constraintsEquation == null) { constraintsEquation = new string[MAX_CONSTRAINT_NUM]; }

                // If there is already constraint called name in list => return error
                for (int i = 0; i < MAX_CONSTRAINT_NUM; i++)
                {
                    if (name == constraintsName[i])
                    {
                        swApp.SendMsgToUser("There is already constraint called " + name + "!");
                        return 0; // Return error
                    }
                }

                // Set equation, name, and increment number of current constraints
                constraintsEquation[numConstraints] = equation;
                constraintsName[numConstraints] = name;
                numConstraints = numConstraints + 1;

                return 1; // Return success
            }


            /// <summary>
            /// Function Name: removeConstraint
            /// Description: Removes a consraint name and equation from the list of current constraints
            /// </summary>
            /// <param name="name">Name of constraint</param>
            /// <returns></returns>
            public int removeConstraint(string name)
            {
                // Iterate through the constraints to check to check for constraint name
                for (int i = 0; i < numConstraints; i++)
                {
                    // if the name of the constraint is found => set the name in list to null
                    if (constraintsName[i] == name)
                    {
                        constraintsName[i] = null;

                        // Reorder the constraints in the list
                        for (int j = i; j < numConstraints; j++)
                        {
                            constraintsName[j] = constraintsName[j + 1];
                            constraintsEquation[j] = constraintsEquation[j + 1];
                        }

                        numConstraints = numConstraints - 1;
                        return 1; // Return success
                    }
                }
                swApp.SendMsgToUser("There is no constraint " + name);
                return 0; // Return error
            }

            /// <summary>
            /// Function Name: setConstraints
            /// Description: constructor - sets the initial constraints variables
            /// </summary>
            public void setConstraints()
            {
                numConstraints = 0;
                constraintsName = new string[MAX_CONSTRAINT_NUM];
                constraintsEquation = new string[MAX_CONSTRAINT_NUM];
            }

        }

        /// <summary>
        ///     Struct: Variable Stuct handling
        ///     Description: Main Back-end for variable handling on CAD objects
        /// </summary>
        public struct Variables
        {
            public int numVariables; // Number of current variables
            public string[] variablesName; // List of variable names
            public string[] variablesMax; // Upper limit on a variable
            public string[] variablesMin; // Lower limit on a variable
            public int[] variablesType; // 0: Double, 1:int

            /// <summary>
            /// Function Name: addVariable
            /// Description: Adds a variable to the current variables list
            /// </summary>
            /// <param name="name">Name of variable</param>
            /// <returns>error - 1, success -  0</returns>
            public int addVariable(string name, string max, string min, int type)
            {
                // If the variable name list is null => set all variable variables
                if (variablesName == null)
                {
                    variablesName = new string[MAX_VARIABLE_NUM];
                    variablesMax = new string[MAX_VARIABLE_NUM];
                    variablesMin = new string[MAX_VARIABLE_NUM];
                    variablesType = new int[MAX_VARIABLE_NUM];
                }

                // If the numer of variables is at max limit => send max limit hit error
                if (numVariables >= MAX_CONSTRAINT_NUM)
                {
                    swApp.SendMsgToUser("Error: Cannot declare more than " + MAX_VARIABLE_NUM + " variables");
                    return 1; // return error
                }

                // Iterate through current variables to see if the variable to be added is a duplicate
                for (int i = 0; i < numVariables; i++)
                {
                    // If duplicate found => send error
                    if (variablesName[i] == name)
                    {
                        swApp.SendMsgToUser("Error: Variable name is already in use");
                        return 1;
                    }
                }

                // If the lower limit is >= the upper limit => send error
                if( float.Parse(min, System.Globalization.CultureInfo.InvariantCulture) >= float.Parse(max, System.Globalization.CultureInfo.InvariantCulture) )
                {
                    swApp.SendMsgToUser("Error: Invalid min and max values");
                    return 1;
                }

                // Set the new variable
                variablesName[numVariables] = name;
                variablesMax[numVariables] = max;
                variablesMin[numVariables] = min;
                variablesType[numVariables] = type;

                numVariables++; // Increment the number of current variables

                return 0; // Return success
            }

            /// <summary>
            /// Function Name: removeVariable
            /// Description: Removes the selected variable from the list of variables
            /// </summary>
            /// <param name="name">The variable name</param>
            /// <returns>0 - success, 1 - error</returns>
            public int removeVariable(string name)
            {
                // Loop through the current variables
                for (int i = 0; i < numVariables; i++)
                {
                    // If the to-be-removed variable is found 
                    // => delete the variable and resort the variable list
                    if (name == variablesName[i])
                    {
                        variablesName[i] = null; // Set the selected variable name to null

                        // Loop through the variable name list from the deleted variable index
                        // to the end of the list to reorder
                        for (int j = i; j < numVariables; j++)
                        {
                            variablesName[j] = variablesName[j + 1];
                            variablesMax[j] = variablesMax[j + 1];
                            variablesMin[j] = variablesMin[j + 1];
                            variablesType[j] = variablesType[j + 1];
                        }

                        numVariables--; // Decrement current variables counter
                        return 0; // Return success
                    }
                }
                swApp.SendMsgToUser("Error: Variable doesn't exist");
                return 1; // Return error
            }

            /// <summary>
            /// Function Name: isVariable
            /// Description: Checks to see if there is a variable with name "name"
            /// </summary>
            /// <param name="name">Name of variable</param>
            /// <returns>true - name exists, false - name doesn't exist</returns>
            public bool isVariable(string name)
            {
                // Loop through current variables
                for (int i = 0; i < numVariables; i++)
                {
                    // If found name => return true
                    if (variablesName[i] == name)
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Function Name: 
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public int indexVariable(string name)
            {
                for (int i = 0; i < numVariables; i++)
                {
                    if (variablesName[i] == name)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void setVariables() //sets variables inputted by user
            {
                numVariables = 0;
                variablesName = new string[MAX_VARIABLE_NUM];
                variablesMax = new string[MAX_VARIABLE_NUM];
                variablesMin = new string[MAX_VARIABLE_NUM];
                variablesType = new int[MAX_VARIABLE_NUM];
            }

            public string[] getValues() //gets values provided by user
            {
                ModelDoc2 swModelDoc = swApp.ActiveDoc;
                EquationMgr swEqnMgr = swModelDoc.GetEquationMgr();

                string[] result = new string[numVariables];

                for (int i = 0; i < swEqnMgr.GetCount(); i++)
                {
                    if (swEqnMgr.GlobalVariable[i])
                    {
                        int index = indexVariable(swEqnMgr.Equation[i].ToString().Split('"')[1]);
                        if (index >= 0)
                        {
                            result[index] = swEqnMgr.Value[i].ToString();
                        }
                    }
                }
                return result;
            }

            public string roundUpValue(string floatString)
            {
                float fnum = float.Parse(floatString);
                int inum = (int)Math.Round(fnum, 0);
                return inum.ToString();
            }
        }


        #endregion

        #region Add-ins

        public bool ConnectToSW(object ThisSW, int Cookie) //This is where we create the UI
        {
            swApp = ThisSW as SldWorks;
            swApp.SetAddinCallbackInfo2(0, this, Cookie);
            SessionCookie = Cookie;
    
            string[] paths = System.Environment.GetEnvironmentVariable("PATH").Split(';');
            foreach (string path in paths)
            {
                if( path.Contains("Python3") && !path.Contains("Scripts") )
                {
                    pythonLocation = path + "python.exe";
                    break;
                }
            }

            LoadUI();//UI is loaded
            
            return true;
        }

        public bool DisconnectFromSW()
        {
            // This is where we destroy the UI

            UnloadUI();
            GC.Collect();
            swApp = null;

            return true;
        }

        private void LoadUI()
        {
            // Add add-ins icon
            var imagePath = Path.Combine(Path.GetDirectoryName(typeof(Addin).Assembly.CodeBase).Replace(@"file:\", ""), "logo-small.png");
            mTaskpaneView = swApp.CreateTaskpaneView2(imagePath, "CS80 Project");

            // Load UI
            mMainUI = (MainUI)mTaskpaneView.AddControl(Addin.SWTASKPANE_PROGID, string.Empty);
            mMainUI.setSolidWorksSingleton(this);
        }

        private void UnloadUI()
        {
            mMainUI = null;
            mTaskpaneView.DeleteView();
            Marshal.ReleaseComObject(mTaskpaneView);

            mTaskpaneView = null;
        }

        // Add to register
        [ComRegisterFunction]
        private static void RegisterAssembly(Type t)
        {
            string Path = String.Format(@"SOFTWARE\SolidWorks\AddIns\{0:b}", t);
            RegistryKey Key = Registry.LocalMachine.CreateSubKey(Path);

            // startup int
            Key.SetValue(null, 1);
            Key.SetValue("Title", "Addin");
            Key.SetValue("Description", "This is a description");
        }

        // Unregister
        [ComUnregisterFunction]
        private static void UnregisterAssembly(Type t)
        {
            string Path = String.Format(@"SOFTWARE\SolidWorks\AddIns\{0:b}", t);
            Registry.LocalMachine.DeleteSubKey(Path);

        }

        #endregion

        #region Helping functions

        public string getPathDebug()
        {
            return Path.GetDirectoryName(typeof(Addin).Assembly.CodeBase).Replace(@"file:\", "");
        }

        private string randomNumber(string max, string min, int type)
        {
            Random rand = new Random();
            if (type == 0)
            {
                float fmax = float.Parse(max);
                float fmin = float.Parse(min);
                float random = fmin + (fmax - fmin) * (float)rand.NextDouble();
                return random.ToString();
            }
            else if (type == 1)
            {
                int imax = (int)Math.Round(float.Parse(max),0);
                int imin = (int)Math.Round(float.Parse(min), 0);
                if (imax == imin)
                {
                    return imax.ToString();
                }
                else
                {
                    int random = imin + rand.Next(2 ^ 10) % (imax - imin);
                    return random.ToString();

                }
            }
            return null;
        }

        public bool setPythonLocation(string path) //This function takes the user's input and syncs with the user's python.exe
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            psi.FileName = path;
            psi.WorkingDirectory = getPathDebug();
            psi.Arguments = "mathFunctions.py";

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            try
            {
                using (Process process = Process.Start(psi))
                {
                    pythonLocation = path;
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string[] runPython(string path)
        {
            string[] result = new string[2];
            result[0] = "";
            result[1] = "";

            ProcessStartInfo psi = new ProcessStartInfo();

            if (pythonLocation == null) //Activates if user hasn't connected their Python.exe
            {
                sendMessageToUser("You have to set your python location");
                //pythonLocation = @"C:\Users\Paul Lee\AppData\Local\Programs\Python\Python37-32\python.exe";
                return null;
            }
            //psi.FileName = @"C:\Users\Paul Lee\AppData\Local\Programs\Python\Python37-32\python.exe";///////////////////////////
            psi.FileName = pythonLocation;
            psi.WorkingDirectory = getPathDebug();
            psi.Arguments = path;

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            using (Process process = Process.Start(psi))
            {
                result[0] = process.StandardOutput.ReadToEnd();
                result[1] = process.StandardError.ReadToEnd();
            }
            return result;
        }

        #endregion

        #region SolidWorks functions

        public string[] getSolidWorksGlobalVariables()
        {
            ModelDoc2 swModelDoc = swApp.ActiveDoc;
            EquationMgr swEqnMgr = swModelDoc.GetEquationMgr();

            string[] temp = new string[swEqnMgr.GetCount()];
            int count = 0;

            for (int i = 0; i < swEqnMgr.GetCount(); i++)
            {
                if (swEqnMgr.GlobalVariable[i])
                {
                    temp[count] = swEqnMgr.Equation[i].Split('\"')[1];
                    count++;
                }
            }
            temp[count] = null;

            return temp;
        }

        public void generateRandomObject() //this function makes the "generate Random Object" button in the GUI work
        {
            string[] arguments = new string[variables.numVariables + constraints.numConstraints+1];
            arguments[0] = variables.numVariables.ToString() + "," + constraints.numConstraints.ToString();
            for (int i = 0; i < variables.numVariables; i++)
            {
                arguments[i+1] = variables.variablesName[i] + "," + variables.variablesMin[i] + "," + variables.variablesMax[i] + "," + variables.variablesType[i].ToString();
            }
            for (int i = variables.numVariables; i < variables.numVariables + constraints.numConstraints; i++)
            {
                arguments[i+1] = constraints.constraintsEquation[i - variables.numVariables];
            }

            writeArgument(arguments);

            string[] pythonResult = runPython("randomSample.py");

            if(pythonResult == null)
            {
                return;
            }
            else if (pythonResult[1] == "false") { //If couldn't create object
                sendMessageToUser("Failed to generate random object");
                return;
            }

            ModelDoc2 swModelDoc = swApp.ActiveDoc;
            EquationMgr swEqnMgr = swModelDoc.GetEquationMgr();

            string[] csStdout = pythonResult[0].Split(',');
            for (int i = 0; i < swEqnMgr.GetCount(); i++)
            {
                if (swEqnMgr.GlobalVariable[i])
                {
                    string newEquation;

                    // Get the variable name from the swEqn

                    string[] temp = swEqnMgr.Equation[i].Split(new string[] { "=" }, StringSplitOptions.None);
                    string name = temp[0];

                    // Get the variable unit from the swEqn

                    Regex re = new Regex(@"([._0-9]+)([a-zA-Z]+)");
                    Match result = re.Match(temp[1]);

                    string unit = result.Groups[2].Value;

                    // Get the index of swEqn variable at variables.

                    temp = temp[0].Split('"');
                    int index = variables.indexVariable(temp[1]);
                    //string[] randomVariables;
                    if (index >= 0)
                    {
                        // No constraints                       

                        //string random = randomNumber(variables.variablesMax[index], variables.variablesMin[index], variables.variablesType[index]);
                        //newEquation = name + "= " + random + unit; // 

                        // HAVE TO COMPARE WITH CONSTRAINTS!!!!!!                       

                        newEquation = name + "= " + float.Parse(csStdout[index]).ToString() + unit;

                        swEqnMgr.Equation[i] = newEquation;
                    }
                }

            }
            swModelDoc.ForceRebuild3(true);
        }

        public void setObject(string[] values)
        {
            ModelDoc2 swModelDoc = swApp.ActiveDoc;
            EquationMgr swEqnMgr = swModelDoc.GetEquationMgr();

            for (int i = 0; i < swEqnMgr.GetCount(); i++)
            {
                if (swEqnMgr.GlobalVariable[i])
                {
                    string newEquation;

                    // Get the variable name from the swEqn

                    string[] temp = swEqnMgr.Equation[i].Split(new string[] { "=" }, StringSplitOptions.None);
                    string name = temp[0];

                    // Get the variable unit from the swEqn

                    Regex re = new Regex(@"([._0-9]+)([a-zA-Z]+)");
                    Match result = re.Match(temp[1]);

                    string unit = result.Groups[2].Value;

                    // Get the index of swEqn variable at variables.

                    temp = temp[0].Split('"');
                    int index = variables.indexVariable(temp[1]);
                    if (index >= 0)
                    {
                        newEquation = name + "= " + values[index] + unit;
                        swEqnMgr.Equation[i] = newEquation;
                    }
                }

            }
            swModelDoc.ForceRebuild3(true);
        }

        public void sendMessageToUser(string message) //for errors (warning yellow triangle)
        {
            swApp.SendMsgToUser(message);
        }

        public void sendMessageToUser2(string message, int icon) //for others (1 == Triangle warning, 2 == "i" bubble, 3 == "?", 4 == "X" 
        {
            swApp.SendMsgToUser2(message, icon, 2);
        }

        public void sendMessageToUser3(string message, int icon) //for others (1 == Triangle warning, 2 == "i" bubble, 3 == "?", 4 == "X" 
        {
            swApp.SendMsgToUser2(message, icon, 3);
        }

        public void sendMessageToUser4(string message, int icon) //for others (1 == Triangle warning, 2 == "i" bubble, 3 == "?", 4 == "X" 
        {
            swApp.SendMsgToUser2(message, icon, 4);
        }

        #endregion

        #region File read write

        public void writeVariablesAndConstraints(string path)
        {
            if (path == null)
            {
                return;
            }
            /* Set File Path */
            ModelDoc2 swModel = swApp.ActiveDoc;
            //string filePath = Path.GetDirectoryName(swModel.GetPathName()) + "\\CS80OptimizationVariablesAndConstraints.csv";
            try
            {
                using (StreamWriter outFile = new StreamWriter(path))
                {
                    outFile.WriteLine("CS80PROJECT_VARIABLES_AND_CONSTRAINTS");

                    /* Write Number of Variables \n Number of Constraints \n*/
                    outFile.WriteLine("{0},{1}", variables.numVariables, constraints.numConstraints);

                    // Write Variables
                    // Name, Max, Min, Type
                    for (int i = 0; i < variables.numVariables; i++)
                    {
                        outFile.WriteLine("{0},{1},{2},{3}", variables.variablesName[i], variables.variablesMax[i], variables.variablesMin[i], variables.variablesType[i]);
                    }

                    /* Write out all of the constraint equations */
                    // Name, Equation
                    for (int i = 0; i < constraints.numConstraints; i++)
                    {
                        outFile.WriteLine("{0},{1}", constraints.constraintsName[i], constraints.constraintsEquation[i]);
                    }
                    //   swApp.SendMsgToUser2("Variables and Constraints are saved",icon,2);
                    sendMessageToUser2("Variables and Constraints are saved", 2);
                }
            }


            catch (Exception e)
            {
                swApp.SendMsgToUser("Save Error"); //There was an error saving
                return;
            }
        }

        public void readVariablesAndConstraints(string path)
        {
            if (path == null)
            {
                return;
            }
            ModelDoc2 swModel = swApp.ActiveDoc;
            //string filePath = Path.GetDirectoryName(swModel.GetPathName()) + "\\CS80OptimizationVariablesAndConstraints.csv";
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = reader.ReadLine();

                    if (line != "CS80PROJECT_VARIABLES_AND_CONSTRAINTS")
                    {
                        swApp.SendMsgToUser("You opened the wrong file");
                        return;
                    }

                    line = reader.ReadLine();
                    string[] csLine = line.Split(',');

                    variables.setVariables();
                    constraints.setConstraints();

                    // Get the number of variables and constraints

                    variables.numVariables = int.Parse(csLine[0]);
                    constraints.numConstraints = int.Parse(csLine[1]);

                    // Read the variables data
                    // Name, Max, Min, Type

                    for (int i = 0; i < variables.numVariables; i++)
                    {
                        line = reader.ReadLine();
                        csLine = line.Split(',');
                        variables.variablesName[i] = csLine[0];
                        variables.variablesMax[i] = csLine[1];
                        variables.variablesMin[i] = csLine[2];
                        variables.variablesType[i] = int.Parse(csLine[3]);
                    }

                    // Read the constraints data
                    // Name, Equation

                    for (int i = 0; i < constraints.numConstraints; i++)
                    {
                        line = reader.ReadLine();
                        csLine = line.Split(',');
                        constraints.constraintsName[i] = csLine[0];
                        constraints.constraintsEquation[i] = csLine[1];
                    }

                    sendMessageToUser2("Variables and constrains have been loaded", 2);
                    //swApp.SendMsgToUser("Variables and Constraints are loaded");
                }

            }

            catch (Exception e)
            {
                swApp.SendMsgToUser("Not available file");
                return;
            }
        }

        public void writeSolidWorksDocumentAsSLDPRT(string path)
        {
            ModelDoc2 swModelDoc = swApp.ActiveDoc;
            swModelDoc.ClearSelection2(true);
            swModelDoc.SaveAs3(path + ".SLDPRT", 0, 0);
        }

        public void writeSolidWorksDocumentAsSTL(string path)
        {
            ModelDoc2 swModelDoc = swApp.ActiveDoc;
            swModelDoc.ClearSelection2(true);
            swModelDoc.SaveAs3(path + ".stl", 0, 0);
        }

        public void writeArgument(string[] arguments)
        {
            try
            {
                using (StreamWriter outFile = new StreamWriter(getPathDebug() + @"\arguments.csv"))
                {
                    outFile.WriteLine(arguments.Length);
                    for (int i = 0; i < arguments.Length; i++)
                    {
                        outFile.WriteLine(arguments[i]);
                    }
                }
            }
            catch (Exception e)
            {
                swApp.SendMsgToUser("Making Argument Error");
            }
        }

        #endregion

        #region Optimization

        public bool optimization(string learningRate) //The optimization function begins here
        {
            string[] pythonResult = runPython("optimization.py");
/*
            if(pythonLocation == null)
            {
                sendMessageToUser("You have to set your python location");
            }
            ProcessStartInfo psi = new ProcessStartInfo();
            //            psi.FileName = @"C:\Users\Paul Lee\AppData\Local\Programs\Python\Python37-32\python.exe";///////////////////////////
            psi.FileName = psi.FileName;
            psi.WorkingDirectory = System.IO.Directory.GetCurrentDirectory();
            psi.Arguments = @"optimization.py";

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            string stderr;
            string stdout;

            using (Process process = Process.Start(psi))
            {
                stderr = process.StandardError.ReadToEnd();
                stdout = process.StandardOutput.ReadToEnd();
            }
*/
            if (pythonResult == null) //could not get Python result
            {
                return false;
            }
            else if (pythonResult[1] != "")
            {
                sendMessageToUser2(pythonResult[1], 2);
            }
            else
            {
                learning(pythonResult[0], learningRate);
                return true;
            }
            return false;
        }

        public void learning (string result, string learningRateString) //learning algorithm
        {
            string[] csResult = result.Split(',');
            float learningRate = float.Parse(learningRateString);
            for (int i = 0; i < variables.numVariables; i++)
            {
                float temp = float.Parse(variables.variablesMax[i]);
                variables.variablesMax[i] = (temp - (learningRate) * (temp - float.Parse(csResult[i]))).ToString();
                temp = float.Parse(variables.variablesMin[i]);
                variables.variablesMin[i] = (temp + (learningRate) * (float.Parse(csResult[i]) - temp)).ToString();
            }
        }
        #endregion
    }
}
