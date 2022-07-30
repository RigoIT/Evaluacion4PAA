using Evaluacion4PAA.Models;

Console.WriteLine("Evaluación 4: PAA Rodrigo Gutiérrez");

using (EFContext bd = new EFContext())
{

    //--------------------------------------------------------Lectura--------------------------------------------------------
    /* 1) Obtener los Cantautores cuyos IDs estén entre 1 y 7, ordenados por Id de forma descendente */
    // SELECT * FROM Cantautor WHERE Id >= 1 AND Id <= 7
    // ORDER BY Id DESC;
    var cantautoresOrdenados = bd.Cantautor
        .Where(x => x.id_cantautor <= 7 && x.id_cantautor >= 1)
        .OrderBy(x => x.id_cantautor)
        .ToList();

    Console.WriteLine("Cantautores Ordenados de Menor a Mayor por su ID");
    foreach (var Cantautor in cantautoresOrdenados)
    {
        Console.Write(Cantautor.id_cantautor);
        Console.Write(" ");
        Console.WriteLine(Cantautor.nombre_cantautor);
    }

    /* 2) Obtener el promedio de la posicion de los artistas */
    // SELECT AVG(posicion) FROM Cancion
    double promedioPosicion = bd.Cancion.Average(x => x.posicion);
    Console.WriteLine(" ");
    Console.WriteLine("Posicion Promedio entre artistas");
    Console.WriteLine(promedioPosicion);
    Console.WriteLine(" ");

    /* 3) Obtener la fecha de ingreso mas temprana de un cantautor en sanremo*/
    // SELECT MIN(primera_presentacion) FROM Cantautor;
    DateTime min = bd.Cantautor.Min(x => x.primera_presentacion);
    Console.WriteLine(" ");
    Console.Write("El Primer Artista en ingresar a Sanremo, lo hizo en el día: ");
    Console.Write(min);
    Console.WriteLine(" ");


    //--------------------------------------------------------Escritura--------------------------------------------------------
    /* 4) Insertar un nuevo Cantautor, sin un ID existente aun, que posea
           las siguientes características:
           Nombre: "Roberto Vecchioni", primera_presentacion: El 31 de enero del 2011,
           Se sabe la actual actividad del autor. 
           Canciones publicadas: 100                  
    */

    // INSERT INTO Cantautor(nombre_cantautor, primera_presentacion, canciones_publicadas, vigencia)
    // VALUES("Roberto Vecchioni", "2011-01-31", 100, true);


    Cantautor nuevoCantautor = new Cantautor()
    {
        id_cantautor = 8,
        nombre_cantautor = "Roberto Vecchioni",
        primera_presentacion = Convert.ToDateTime("2011-01-31"),
        canciones_publicadas = 100,
        vigencia = true
    };

    bd.Cantautor.Add(nuevoCantautor);
    bd.SaveChanges();

    Console.WriteLine(" ");
    Console.Write("Se ha añadido al artista: ");
    Console.Write(nuevoCantautor.nombre_cantautor);
    Console.WriteLine(" ");


    //--------------------------------------------------------Actualización--------------------------------------------------------
    /* 5) Actualizar el Nombre del autor "Al Bano & Romina Power" a "Al Bano" y la cantidad de obras de 250 a 300
           a través de la búsqueda de su id */
    // UPDATE Cantautor SET nombre_cantautor = 'Al Bano' WHERE Id = 5;
    // UPDATE Cantautor SET canciones_publicadas = '300' WHERE Id = 5;
    var cantautorEditar = bd.Cantautor.FirstOrDefault(x => x.id_cantautor == 5);

    cantautorEditar.nombre_cantautor = "Al Bano";
    cantautorEditar.canciones_publicadas = 300;
    bd.Cantautor.Update(cantautorEditar);
    bd.SaveChanges();

    Console.WriteLine(" ");
    Console.WriteLine("Se actualizaron los siguientes datos del cantautor Al Bano & Romina Power: ");
    Console.Write("Nombre Actualizado: ");
    Console.Write(cantautorEditar.nombre_cantautor);
    Console.WriteLine(" ");
    Console.Write("Canciones Publicadas Actualizadas: ");
    Console.Write(cantautorEditar.canciones_publicadas);
    Console.WriteLine(" ");

    //--------------------------------------------------------Eliminación--------------------------------------------------------
    /* 6) Eliminar la cancion "Un Diadema Di Ciliegie"
          a través del ID (28)
    */
    //DELETE from Cancion where Id=28;

    var cancionEliminar = bd.Cancion.FirstOrDefault(x => x.id_cancion == 28);
    bd.Cancion.Remove(cancionEliminar);
    bd.SaveChanges();
    Console.WriteLine(" ");
    Console.Write("Se eliminó la canción: ");
    Console.Write(cancionEliminar.nombre_cancion);
    Console.WriteLine(" ");
}
