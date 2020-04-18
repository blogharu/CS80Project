# Capstone Project

Our Capstone Project is a project to automate SolidWorks operations from: generating new randomized objects to creating variables and constraints to keep objects in a certain shape and size, and optimize the objects based off of experimental data using statistics.

## Installation

Clone the repository into a given directory

``` bash
git clone https://github.com/blogharu/CS80Project.git
```

## Dependencies

This projects uses:

- Visual Studio
- C#
- SolidWorks 2019
- Python3.4 and up
  - NumPy
  - SciPy

This project also uses references in Visual Studios to run properly:

SolidWorks:

- SolidWorks.Interop.sldworks.dll
- SolidWorks.Interop.swcommands.dll
- SolidWorks.Interop.swconst.dll
- SolidWorks.Interop.swdocumentmgr.dll
- SolidWorks.Interop.swpublished.dll

How to:

- Right click the project in the right panel
- Hover over "add" in the right click menu
- Click "reference"
- A pop-up will appear asking you to browse for the listed files above
  - Defaul directory is: C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS
- Select the above files and add them

## Usage

Once cloned into a directory and having referenced all of the dependencies, one can build this project in Visual Studios using admin/root privillages, then start SolidWorks, and there will be a Pikachu icon on the left menu bar; this is the add-on. There are a variety of features such as:

- Adding and Deleting variables
- Listing variables
- Adding and Deleting constraints
- Listing constraints
- Auto generating a certain number of random objects and saving them as either STL or SLDWRKS files
- Running a dataset through the Python optimization program.

This program uses a formatted file for the datasets thats auto generated by the add-on. The Python optimization program uses this same file but with filled in data for the experimental data that is left blank upon generation.

Steps to use program:

1. Download the code from github,
2. Open the program in Visual Studios in Administrator Mode (It's crucial that it's done in administrator mode, to allow the necessary permissions)
3. Open the solution from our github.
4. Grab the following files from your SolidWorks folder found on the C Drive:
    - SolidWorks.Interop.sldworks.dll
    - SolidWorks.Interop.swcommands.dll
    - SolidWorks.Interop.swconst.dll
    - SolidWorks.Interop.swdocumentmgr.dll
    - SolidWorks.Interop.swpublished.dll

    and place them in CS80project->bin-Debug
  
5. Build the program
    - Note: Running it will cause an error as it is not an executable
6. Launch SolidWorks, click the pikachu icon and connect the python.exe

## Demo Video

Below links to a demo video:

- [Capstrone 80 - Demo Video](https://youtu.be/ybNKb1qOqOw "Capstone 80 - Demo Video")
