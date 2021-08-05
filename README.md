# Lazy Calculator

The application reads UTF-8 encoded textfiles containing commands for the calculator. Filepath can be specified through command line input, if no path is specified 'math_data_3.txt' will be defaulted.

Operations the calculator can not determine directly, will by evaluated at print. Therefore the name 'Lazy Calculator'.

Examples of accepted input can be found in 'math_data_1.txt', 'math_data_2.txt' & 'math_data_3.txt'.

Written in C# 7.9, .NET Core 2.1.

## Valid commands

List of valid commands.

### Mathematical

- _registername_ **add** _value_
- _registername_ **substract** _value_
- _registername_ **multiply** _value_

Note:

value can be a registernname, if they can be evaluated at print.

### Other

- _print_ **registername**

Note:

_registername_ has to either have a value in the register, or the possibility to be evaluated.

## Requirements

- .NET Core 2.1

## Running the application

Easiets way to run the application is by executing 'RunApplication.bat' which runs 'dotnet Calculator.dll' for you. Tests can be ran through Visual Studio.

## Solution Structure

- 'Calculator/' contains the Application
- 'Test/' contains tests written using NUnit3.
