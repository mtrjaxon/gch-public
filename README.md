# GCH (Garry's Mod Content Helper) - GCH3

GCH (Garry's Mod Content Helper) is your ultimate tool for preparing Garry's Mod addons for compression with GAC (Garry's Mod Addon Compressor). GCH3 introduces significant enhancements, including invoke-based threading for improved stability and a reworked UI for better legibility.

## What's New in GCH3

- **Invoke-Based Threading**: I've replaced the previous task-based threading system with invoke-based threading. This change reduces crashes, freezes, and errors, ensuring a smoother experience.
- **Reworked UI**: The interface has been updated to make it more user-friendly and easier to navigate.
- **Full Featureset**: There are no longer any expirimental functions in GCH, they have all been fixed and added to the full feature pool.

## Tutorial: Using GCH3 for Garry's Mod Content Packs

### Video Tutorial

For a visual guide, check out this comprehensive [video tutorial](https://www.youtube.com/watch?v=WX4Z8od8zgE&feature=youtu.be) on using GCH3 for Garry's Mod content packs.

## Prerequisites

Before using GCH3, make sure you have:

- GCH3 installed on your system.
- `.gma` files of the addons you want to work with. These can be obtained from the Garry's Mod workshop folder or the legacy addons folder.

## Getting Started

1. Create a working directory on your system for your addons.
2. Copy the `.gma` files you wish to extract and optimize into this directory.

## Extracting Addons

1. Open GCH3 and navigate to your working directory.
2. Click the "Open Directory" button. If you encounter errors, it might be due to too many files to read.
3. Once the directory is successfully opened, click the "Extract" button.
4. GCH3 will extract the contents of the `.gma` files into the same directory.

## Compressing Addons with GAC (Garry's Mod Addon Compressor)

1. Download and open GAC (Garry's Mod Addon Compressor) from [here](https://github.com/Shark-vil/GmodAddonCompressor/releases/tag/v2.0.4).
2. In GAC, select the folder where you extracted the addon contents using GCH3.
3. GAC will compress the addons into the final format.

## Repacking Compressed Addons

To repack the compressed addons:

1. After GAC finishes compressing, return to GCH3.
2. Click the "Pack" button.
3. GCH3 will repack the compressed addons into `.gma` files, ready for use.

## Creating the Content Pack

To create the content pack:

1. Click the "Create" button in GCH3.
2. The creation process will take a moment. Pay attention to any file conflicts alerted by GCH3.
3. Once complete, you'll find two folders:
   - **release**: Contains raw content pack information (not in `.gma` format).
   - **bin**: Contains the `gchcontentpack.gma` file, which you can upload to the workshop.

## Additional Notes
  
- **Asynchronous Merging**: GCH3 includes a full release of asynchronous merging, providing notable speed improvements over its predecessor.

- **Debugging GMAD Errors**: If you encounter GMAD-related issues, uncomment specific lines in the GCH3 code for error debugging. Locate the following lines in the code:

    ```csharp
    /* This is for debugging errors in GMAD, not GCH !!!!!!!!! THIS NEEDS TO BE CHANGED !!!!!!!!!!! IT IS DONE A DIFFERENT WAY NOW
        -- process.ErrorDataReceived += Process_ErrorDataReceived;
        -- process.OutputDataReceived += Process_OutputDataReceived;
    */
    ```

    Remove the `/*` and `*/` to uncomment these lines for more detailed error information.

- **Message Box Prompts**: Unlike GCH1, GCH2's logging system is more actively used. Message boxes will only appear for immediate actions or file conflicts.

- **Addon.json File Replacement**: GCH3 creates a new `addon.json` file for each extracted `.gma` file. If an `addon.json` file already exists, it will be replaced with the updated version to reflect any changes made during optimization.
