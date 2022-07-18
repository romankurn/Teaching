using System;
using System.IO;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Helpers
{
	public class FileReader
	{
		
		public async Task<byte[]> ReadFileAsync(string path)
		{
			try
			{
				
				using (FileStream fstream = File.OpenRead(path))
				{
					
					byte[] buffer = new byte[fstream.Length];
					
					await fstream.ReadAsync(buffer, 0, buffer.Length);

					return buffer;
				}
			}
			catch (FileNotFoundException ex)
			{
				return null;
			}
		}

	}
}
