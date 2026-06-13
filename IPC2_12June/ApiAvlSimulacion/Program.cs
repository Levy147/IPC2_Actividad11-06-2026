using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Simulación del estado del árbol en memoria
// Estado inicial desbalanceado en Zig-Zag
var estadoArbol = new List<NodoAVL>
{
    new NodoAVL { Id = 30, Etiqueta = "Nodo Raiz (Abuelo) - FE: -2" },
    new NodoAVL { Id = 10, Etiqueta = "Hijo Izquierdo - FE: +1" }
};

//Recupera la estructura física del árbol actual
app.MapGet("/api/arbol", () => Results.Ok(estadoArbol));

// NDPOINT POST: Simula la inserción que gatilla el balanceo compuesto
app.MapPost("/api/arbol/insertar", (NodoAVL nuevoNodo) =>
{
    // Validación básica de la llave
    if (nuevoNodo.Id <= 0) return Results.BadRequest("ID de nodo inválido.");

    // Al insertar el 20, se detecta el caso cruzado Izquierda-Derecha
    if (nuevoNodo.Id == 20)
    {
        estadoArbol.Clear();
        
        // El resultado de la rotación RID balancea perfectamente el árbol
        estadoArbol.Add(new NodoAVL { Id = 20, Etiqueta = "Nueva Raiz Balanceada (RID) - FE: 0" });
        estadoArbol.Add(new NodoAVL { Id = 10, Etiqueta = "Hijo Izquierdo - FE: 0" });
        estadoArbol.Add(new NodoAVL { Id = 30, Etiqueta = "Hijo Derecho - FE: 0" });
        
        return Results.Created("/api/arbol", new { 
            Mensaje = "Rotación RID ejecutada con éxito. Estabilidad total lograda.", 
            Estructura = estadoArbol 
        });
    }

    // Inserción tradicional sin rotación compuesta
    estadoArbol.Add(nuevoNodo);
    return Results.Created($"/api/arbol/{nuevoNodo.Id}", nuevoNodo);
});

app.Run();

// El Modelo del Nodo (Estructura de la Sesión)
public class NodoAVL
{
    public int Id { get; set; } // Actúa como el Dato/Llave
    public string Etiqueta { get; set; } = string.Empty;
    public int Altura { get; set; } = 1;
}