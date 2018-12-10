Jonathan Godley - c3188072
INFT3050 ASSIGNMENT 2

NOTES:
So I didn't get a chance to salt and hash the passwords like I wanted.
and the Parent Validation email system is also incomplete.

You'll start logged in, but you can log out and create a new account easilly, left you logged in for ease of testing.

Whilst the project is named assig1 it is actually assig2, I simply couldn't rename the project easilly without having a shitload of problems with namespaces etc.

My modified database file is attached as c3188072_assig2udbBETTER.sql

For testing purposes, the ParentPin is effectively set to 1234 for all accounts, 

This assignment makes use of Bootstrap templates for CSS and visual appearance. I've modified small
parts of the template for my own use, notably for the Master-Page's header.

When testing make sure you haven't escaped the route config, you should be on 
http://localhost:49320/BattleSummary/
not 
http://localhost:49320/User_Layer/BattleSummary/
shouldn't happen naturally, but when launching from VStudio it can sometimes escape.

VBCSCompiler.exe kept acting weird. If you get any weird errors when compiling, please clean & rebuild solution, 
if any files "cannot be deleted" check for the VBCScompiler and end the process, then clean & rebuild

For my Parent Pin input, I've sourced some Javascript code to only allow number entry
sourced from https://stackoverflow.com/questions/9732455/how-to-allow-only-integers-in-a-textbox with thanks to "EIV" & "Matt H"
