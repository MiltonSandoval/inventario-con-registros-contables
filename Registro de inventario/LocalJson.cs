using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

public class JsonAlmacen<T>
{
    private string _filePath;

    public JsonAlmacen(string NombreArchivo)
    { 
        string RutaDocumento = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        _filePath = Path.Combine(RutaDocumento, NombreArchivo);
    }


    public void Guardar(T data)
    {
        try
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar datos: {ex.Message}");
        }
    }

    public T CargarDatos()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                T data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
            else
            {
                Console.WriteLine($"No se encontró el archivo en la ruta: {_filePath}. Devolviendo el valor predeterminado.");
                return default(T);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar datos: {ex.Message}");
            return default(T);
        }
    }

    public bool Exists()
    {
        return File.Exists(_filePath);
    }
}
