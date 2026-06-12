# Actividad de Investigación y Práctica: Estructuras de Datos Avanzadas y APIs con ASP.NET Core

## Parte 1: Investigación Teórica

### 1. Estructuras de Datos Eficientes

* **Árboles Binarios de Búsqueda (ABB): En un ABB, para cualquier nodo dado, todos los valores ubicados en su subárbol izquierdo deben ser estrictamente menores que el valor del nodo raíz, y todos los valores en su subárbol derecho deben ser estrictamente mayores.
    * **Principal desventaja (Inserción secuencial):** Si los datos se insertan de forma ya ordenada o secuencial (ej. 1, 2, 3, 4, 5), el árbol nunca se ramifica hacia el otro lado. Como resultado, degenera en una estructura lineal (una lista vinculada), lo que provoca que el tiempo de sus operaciones caiga de una eficiencia logarítmica a un tiempo lineal de $O(n)$.

* **Árboles AVL:**
    * **Definición:** Es un árbol binario de búsqueda auto-balanceado. Esto significa que reajusta automáticamente su estructura interna durante cada inserción o eliminación para evitar desequilibrios.
    * **Factor de Balanceo:** Se evalúa mediante la fórmula: 
        $$\text{Factor} = \text{Altura}_{\text{Izquierda}} - \text{Altura}_{\text{Derecha}}$$
        Un árbol AVL se considera balanceado si el factor de cada nodo es únicamente $-1$, $0$ o $1$.
    * **Complejidad constante en $O(\log n)$:** Al mantener el factor de balanceo bajo control mediante "rotaciones" (simples o dobles) cuando se rompe la regla, el árbol asegura que su altura total siempre sea la mínima posible. Esto garantiza que las operaciones de búsqueda, inserción y eliminación siempre tomen un tiempo logarítmico.

---

### 2. Fundamentos de Web APIs

* **¿Qué es una API y el Modelo Cliente-Servidor?**
    * Una **API** (Interfaz de Programación de Aplicaciones) es un conjunto de reglas y protocolos que permite que distintas aplicaciones de software se comuniquen entre sí y compartan datos de forma segura.
    * En el **Modelo Cliente-Servidor**, la comunicación fluye en dos vías. Un **Cliente** (que puede ser un navegador web, una aplicación móvil o una herramienta como Postman) inicia la comunicación enviando una **Petición (Request)** HTTP al servidor a través de la red. El **Servidor** recibe esta solicitud, ejecuta la lógica necesaria (como consultar una base de datos) y devuelve una **Respuesta (Response)** HTTP al cliente, la cual contiene un código de estado (ej. 200 OK) y los datos solicitados (usualmente en formato JSON).

* **Verbos HTTP:**
    * **GET (Recuperación de recursos):** Se utiliza estrictamente para leer o consultar datos del servidor, sin causar ninguna modificación en ellos. Es una operación **idempotente**, lo que significa que puedes realizar la misma petición GET múltiples veces y el estado del servidor (o de la base de datos) no cambiará en absoluto.
    * **POST (Creación de nuevos recursos):** Se utiliza para enviar datos al servidor con el objetivo de crear un recurso completamente nuevo. **No es idempotente**, ya que si envías exactamente la misma petición POST varias veces, crearás múltiples registros duplicados en el servidor.

    https://github.com/Levy147/IPC2_Actividad11-06-2026.git
