***Authored by Samuel Kennedy - ske131***

# GitHub Instructions

## Creating a new Repository (using Visual Studio Code)

**Step 0)** Ensure that a .gitignore file is placed in the directory of the Unity or Unreal project that you wish to upload.

* <https://github.com/github/gitignore/blob/main/Unity.gitignore>
* <https://github.com/github/gitignore/blob/main/UnrealEngine.gitignore>

**Step 1)** Create a new repository on github.com

**Step 2)** In Visual Studio Code, along the top toolbar, click Terminal -> New Terminal. This should ideally be a PowerShell/Bash terminal to avoid errors.

**Step 3)** Initializing the Repository:

Enter the following commands line by line:

* *git init*
* *git config user.name "YOUR-FIRST-NAME"*
* *git config user.email "YOUR-UC-EMAIL"*
* *git add .gitignore*
* *git commit -m "first commit"*
* *git branch -M main*
* *git remote add origin https://github.com/YOUR-GIT-NAME/YOUR-REPO-NAME.git*
* *git remote -v*
* *git push -u origin main*

  * the url for *git remote add origin* can be found at the top of a new blank git repo on GitHub.com
  * *git remote -v* will check that the repo is correct before pushing

# EngGit Instructions (using Visual Studio Code)

*Ensure the C# Extension is installed if using for Unity*

* In the extension settings, ensure that "Omnisharp: Use Modern Net" is *DISABLED*

## Uploading a New Repository

**Step 0)** Ensure that a .gitignore file is placed in the directory of the Unity or Unreal project that you wish to upload.

* <https://github.com/github/gitignore/blob/main/Unity.gitignore>
* <https://github.com/github/gitignore/blob/main/UnrealEngine.gitignore>

**Step 1)** Open the Unity Project in Visual Studio Code. There are two ways to do this:

* In Visual Studio Code: File -> Open Folder -> (Directory of the project) -> Open.
* In Unity, go to File -> "Preferences" and ensure that under "External Tools" Visual Studio Code is selected as your External Script Editor. Next, right click in the Assets window and click "Open C# Project". This will open the entire project in Visual Studio Code.
* Unreal Engine uses Visual Studio Community by default. However, if you wish to change the default IDE to Visual Studio Code, you can follow the instructions linked below. Using Visual Studio Community for code editing and Visual Studio Code for Version Control will not cause any problems in your workflow.
  * <https://dev.epicgames.com/documentation/en-us/unreal-engine/setting-up-visual-studio-code-for-unreal-engine>

**Step 2)** In Visual Studio Code, along the top toolbar, click Terminal -> New Terminal. This should ideally be a PowerShell/Bash terminal to avoid errors.

**Step 3)** Initializing the Repository:

Enter the following commands line by line:

* git init --initial-branch=main
* git config user.name "YOUR-FIRST-NAME"
* git config user.email "YOUR-UC-EMAIL"
* git add .gitignore
* git commit -m "Added gitignore"
* git push --set-upstream <https://eng-git.canterbury.ac.nz/YOUR-USER-CODE/YOUR-REPO-NAME> main

***Step 3.5)*** *If the EngGit window appears, enter your credentials and sign in.*

**Step 4)** Enter the following line:

* git remote add origin <https://eng-git.canterbury.ac.nz/YOUR-USERCODE/YOUR-REPO-NAME.git>

This line will be part of the output from the following line after signing into EngGit, formatted "YOUR-REPO-NAME.git".

---------------------------------------------------------------------------------------------------

### *CUSTOMISED TERMINAL LINES FOR SKE131:*

*git init --initial-branch=main*

*git config user.name "Samuel"*

*git config user.email "<ske131@uclive.ac.nz>"*

*git add .gitignore*

*git commit -m "Added gitignore"*

*git push --set-upstream <https://eng-git.canterbury.ac.nz/ske131/YOUR-REPO-NAME> main*

*git remote add origin <https://eng-git.canterbury.ac.nz/ske131/YOUR-REPO-NAME.git>*

---------------------------------------------------------------------------------------------------

## Downloading a Repository

**Step 1)** Open Visual Studio Code. In the Left hand taskbar, select the Branch icon to open the Source Control window, and select "Clone Repository".

**Step 2)** Enter the URL for your project. This will be in the format:

* <https://eng-git.canterbury.ac.nz/YOUR-USERCODE/YOUR-REPO-NAME>

This can be found on the EngGit website by opening a project, clicking the dropdown arrow on the blue "Code" button and copying the "Clone with HTTPS" link.

**Step 3)** Chose a file location to clone the repository. On University computers, this should be C:/Local/YOUR-USER-CODE/ or D:/Local/YOUR-USER-CODE if available.

## Staging and Uploading Changes

After making changes, open the Source Control window on the left hand taskbar (Branch icon). To prepare files for upload, click the small "+" icon next to the word Changes to stage these changes for upload. Once the files are now under the heading "Staged Changes", enter a message into the window above detailing your changes, and click "Commit". You may also need to repeat this message and click "Publish".

## Pulling Changes

In Visual Studio Code, open Source Control window on the left hand taskbar (Branch icon), and press the "Sync Changes" button to download all uploaded changes.

## Adding Collaborators to a Repository

On the EngGit website, open your project. On the left-hand panel, hover over "Manage" and select "Members", and in the popup menu, enter the persons user code or name to invite them to the project.

## Changing a Git Commit Message

1) Open the Command Line in the repository of the message you want to amend
2) Type "git commit --amend" and press enter
3) Type a new commit message and save the commit

## Checking for Newly Created branches

To update the local list of  / check for new remote branches:
*git remote update origin --prune*

To show all local and remote branches that (local) Git knows about:
*git branch -a*
