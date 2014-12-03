WordADay
========
***The only place on the internet to find words.***

***Really. It is.***

Get a new word with definition every time you open the program.

## Building WordADay
WordADay can be *very* weird to build, because it uses a specific .DLL
that looks like it is included but isn't, which you must add yet again.

- Step One: Adding the .DLLs
The .DLL is included in the root folder of WordADay, and is called
**MahApps.Metro**. Depending on what version of Visual Studio you use,
it will be a bit different but the important part is this:

- Go to your References folder in the Solution Explorer.
- Right click and click on "Add Reference".
- Navigate to **MahApps.Metro.dll** and choose it under browse.

**Now, do the same thing except for with the .dll **System.Windows.Interactivity**.

- Step Two: Building the Project
Now you should be able to build the project and start working! Awesome!
