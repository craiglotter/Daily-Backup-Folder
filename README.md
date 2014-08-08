Daily Backup Folder
===================

Daily Backup Folder allows the user to select a folder which they wish to back up to another location, and then backs up that folder on a daily basis to the specified backup location.

If an existing backup folder is located in the specified location, then Daily Backup Folder simply copies over newer files than those already existing in the backed up location.

Created by Craig Lotter, June 2008

*********************************

Project Details:

Coded in Visual Basic .NET using Visual Studio .NET 2008
Implements concepts such as Timers, Folder Manipulation, File Manipulation, Threading
Level of Complexity: Simple

*********************************

Update 20080612.02:

- Added Minimise to Notification Tray option
- Changed way in which folder settings memory works
- Removes content from previously backed up sessions that no longer exists in the source folder

*********************************

Update 20080615.03:

- Changed Order in which existing Backup cleanup operation executes to process folders ahead of files.
- Added 'currently processing' labels for both source folder and backup folder activity
- Added link to error log
- Added minimise window option for when the backup operation is in progress
