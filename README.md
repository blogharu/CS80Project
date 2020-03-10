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
- Python3
  - NumPy
  - SciPy

This project also uses references in Visual Studios to run properly:

SolidWorks:

- SolidWorks.Interop.sldworks
- SolidWorks.Interop.swcommands
- SolidWorks.Interop.swconst
- SolidWorks.Interop.swdocumentmg
- SolidWorks.Interop.swpublished

## Usage

Once cloned into a directory and having referenced all of the dependencies, one can build this project in Visual Studios using admin/root privillages then start SolidWorks and there will be a Pikachu icon on the left menu bar; this is the add-on. There are a variety of features such as:

- Adding and Deleting variables
- Listing variables
- Adding and Deleting constraints
- Listing constraints
- Auto generating a certain number of random objects and saving them as either STL or SLDWRKS files
- Running a dataset through the Python optimization program.

This program uses a formatted file for the datasets thats auto generated by the add-on. The Python optimization program uses this same file but with filled in data for the experimental data that is left blank upon generation.

## Contributing

