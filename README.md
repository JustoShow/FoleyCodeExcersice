# Foley Code Exercise

For this exercise, I decided to break it up into different methods.  
I also decided to go with a Test Driven plan using MSUnitTesting.  
The .csv testing file is located at **FileParser\FileParserTest\TestData**

## Basic Steps

1. Load the .csv file (hard coded for this example)
2. Loops through the lines in the file (skips the header) cleans and split the line by the delimiter.  
   Some lines (Records) can have commas (,) inside of string and/or multiple double quotes (") that needs to be cleaned to properly be delimited.
3. Manually parse the lines to an object model called **Person**
4. Add each **Person** to list named **People**

## Running the application

1. Clone the Repository
2. Navigate to **FileParser\FileParseConsoleApp\bin\Release\net5.0**
3. Run **FileParseConsoleApp.exe**

Running Console

![Running Console App](Images/ConsoleApp.jpg)
