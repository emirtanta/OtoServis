﻿namespace OtoServis.WebUI.Utils
{
    public class FileHelper
    {
        /// <summary>
        /// dosya yükler
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string filePath = "/Img/")
        {
            var fileName = "";
            if (formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/" + filePath + fileName;
                using var stream = new FileStream(directory, FileMode.Create);
                await formFile.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}