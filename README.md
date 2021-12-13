# Unity editor plugin [Time recorder]
Time recoder is an Unity Editor plugin that allow you an easy way to track develop work time while unity editor is open, track your develop time per project while this plugin is imported.

![Image of time recorder](./img/time-recorder.webp)

<div class="page-break"></div>

# Installation

- Install via  Asset store:[![Image of time recorder path](./img/asset-store.webp)](https://assetstore.unity.com/packages/add-ons/time-recorder-190927)

- Install via custom package: [TimeRecorder.unitypackage](./TimeRecorder.unitypackage)

<div class="page-break"></div>

# Instructions/requirements
- Make sure only copy repo assets folder into your assets/plugins folder inside your project
- Have installed UIElements package for unity

You can find the time recorder window at Tools/Time recorder

![Image of time recorder path](./img/time-recorder-path.webp)

![Image of time recorder](./img/time-recorder.webp)

<div class="page-break"></div>

# Time recorder tools

You can find the time recorder tools at Tools/Time recorder tools

![Image of time recorder tools path](./img/time-recorder-tools-path.webp)

- In the case you want to make a backup of you "time recorder" data you can make a file backup with the "Generate backup" option.

- I case you want to restore your time recorded data, you can use a backup file to restore your "Time recorder" data

![Time recorder tools](./img/time-recorder-tools.webp)

<br/>

<div class="page-break"></div>

# Edit time
You can edit each day worked time by hovering the day and clicking the edit button. This function only works with the days of selected month (those days which contains the day number).

![Time recorder tools](./img/time-recorder-edit-button.webp)

Once you clicked the edit button the content of the day will change into an input where you can update the time recoder on that day, the value must be setted as minutes.

![Time recorder tools](./img/time-recorder-edit-button-active.webp)

after edit the value you can click save and it will restore the state of the element and the total dev time value will be updated also.

<div class="page-break"></div>

# Extra info
- TimeRecorder automatically start their process on open your Unity Project.
- The time that you spend on your project is saved each 5 minutes or when you close your project.
- You can change between months with the arrow buttons located in the window header.
- Month name is displayed according user os language location.
- In case of try to repaint window, you can find a custom menu option into the 3 dots window button and force repaint.
- Now you can  pause the time recorder actions

![Image of time recorder repaint path](./img/repaint-option.webp)
