# GCH (Gmod Content Helper)

GCH (Gmod Content Helper) is a tool designed to assist with the preparation of Garry's Mod addons for compression using GAC (Gmod Addon Compressor). GCH provides utilities and functions to help optimize and organize addon files before compressing them with GAC.

## Tutorial: Using GCH

### Prerequisites

Before using GCH, make sure you have the following:

- GCH installed on your system. (Provide instructions on how to install GCH, if necessary)
- .gma files of the addons you want to work with. If you don't have any .gma files, you can obtain them from the Garry's Mod workshop.

### Getting Started

1. Create a folder on your system where you want to work with your addons.
2. Copy the .gma files you want to extract and optimize into this folder.

### Extracting Addons

1. Open the GCH tool and navigate to the folder where you placed your .gma files.
2. Click on the "Extract" button in GCH.
3. GCH will extract the contents of the .gma files into the same folder.

### Compressing Addons with GAC

1. Open GAC (Gmod Addon Compressor).
2. In GAC, select the folder where you extracted the addon contents using GCH.
3. GAC will compress the addons into the final format.

### Repacking Compressed Addons

1. Once GAC has finished compressing your addons, navigate back to GCH.
2. In GCH, click on the "Pack" button.
3. GCH will automatically repack the compressed addons, ensuring they are ready for use.

### Additional Notes

- **Debugging GMAD Errors**: In the GCH code, there are lines that handle debugging errors in GMAD (Garry's Mod Addon Creator). If you encounter issues related to GMAD, you can uncomment the following lines to enable error debugging:

    ```csharp
    /* This is for debugging errors in GMAD, not GCPO
        -- process.ErrorDataReceived += Process_ErrorDataReceived;
        -- process.OutputDataReceived += Process_OutputDataReceived;
    */
    ```

  Uncommenting these lines will provide more detailed error information in case of GMAD-related problems.

- **Message Box Prompt**: By default, GCH will prompt you with message boxes during certain operations. This feature is helpful for understanding what's happening behind the scenes. However, if you find it too intrusive, you can disable the message boxes by modifying the appropriate settings in the tool. It is generally recommended to leave this feature enabled unless you encounter issues.

- **Addon.json File Replacement**: GCH creates an addon.json file for each extracted .gma file. In the event that an addon.json file already exists, GCH will replace it with the newly generated one. This ensures that the addon.json remains up to date with any changes made during the optimization process.

---
