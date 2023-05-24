# GCH (Gmod Content Helper)

GCH (Gmod Content Helper) is a tool designed to assist with the preparation of Garry's Mod addons for compression using GAC (Gmod Addon Compressor). GCH provides utilities and functions to help optimize and organize addon files before compressing them with GAC. This tool simply accelerates the process using GMAD, which was created by Facepunch.

### Tutorial: Using GCH for Garry's Mod Content Packs

### Video Tutorial: GCH - Gmod Content Helper

If you prefer visual instructions, you can watch this comprehensive [video tutorial](https://www.youtube.com/watch?v=WX4Z8od8zgE&feature=youtu.be) on using GCH (Gmod Content Helper) for Garry's Mod.

## Prerequisites

Before you start using GCH (Garry's Mod Content Helper) for packaging your Garry's Mod addons, make sure you have the following:

- GCH installed on your system.
- .gma files of the addons you want to work with. If you don't have any .gma files, you can obtain them from either the Garry's Mod workshop folder or the legacy addons folder.

### Getting Started

1. Create a folder on your system where you want to work with your addons.
2. Copy the .gma files you want to extract and optimize into this folder.

### Extracting Addons

1. Open the GCH tool and navigate to the folder where you placed your .gma files.
2. Click on the "Open Directory" button in GCH. If you encounter an error, it may indicate that there are too many files to read.
3. Once the directory is opened successfully, click on the "Extract" button in GCH.
4. GCH will extract the contents of the .gma files into the same folder.

### Compressing Addons with GAC (Garry's Mod Addon Compressor)

1. Download and open GAC (Gmod Addon Compressor) from [here](https://github.com/Shark-vil/GmodAddonCompressor/releases/tag/v2.0.4).
2. In GAC, select the folder where you extracted the addon contents using GCH.
3. GAC will compress the addons into the final format.

### Repacking Compressed Addons

1. Once GAC has finished compressing your addons, go back to GCH.
2. In GCH, click on the "Pack" button.
3. GCH will automatically repack the compressed addons, ensuring they are ready for use.
4. You will receive two folders from this action: "release" and "bin." The "release" folder contains the content pack's merged code and resources, while the "bin" folder contains the gchcontentpack.gma file, which is the addon you will upload.

### Additional Notes

- **Experimental Features**: GCH offers experimental features that you can enable by going to Options and clicking on "Experimental Features." Enabling this feature makes the "Create" button available. When using this feature, ensure that your extracted folder is still present and click on "Create." It is highly recommended to keep the file size below 900 Megabytes to avoid potential issues with the GMAD tool.

- **Debugging GMAD Errors**: If you encounter issues related to GMAD (Garry's Mod Addon Creator), you can uncomment specific lines in the GCH code to enable error debugging. To do this, locate the following lines in the code:

    ```csharp
    /* This is for debugging errors in GMAD, not GCH
        -- process.ErrorDataReceived += Process_ErrorDataReceived;
        -- process.OutputDataReceived += Process_OutputDataReceived;
    */
    ```

    Remove the `/*` and `*/` around these lines to uncomment them. This will provide more detailed error information in case of GMAD-related problems.

- **Message Box Prompt**: By default, GCH displays message boxes during certain
