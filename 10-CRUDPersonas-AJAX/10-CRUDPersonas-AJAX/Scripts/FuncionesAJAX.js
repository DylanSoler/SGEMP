window.onload = inicializaEventos;

function inicializaEventos() {

    cargarLista();
    document.getElementById("create").addEventListener("click", clickCrear, false);
}


// Hace una peticion get a la api y ejecuta la funcion crearTabla a partir del resultado obtenido
function cargarLista() {

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://apirestpersonasdylan.azurewebsites.net/api/Personas/");

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {

            var arrayPersonas = JSON.parse(miLlamada.responseText);
            crearTabla(arrayPersonas);
        }
    }

    miLlamada.send();
}


//Crea una tabla de personas html a partir de un listado
function crearTabla(listado) {

    //Crear tabla
    var table = document.getElementById("tablaPersonas");


    //insertar filas
    for (var i = 0; i < listado.length; i++) {
        var fila = document.createElement("tr");

        //  insertar celdas por fila

        //insertar celdas de las propiedades
        for (var prop in listado[0]) {
            var celda = document.createElement("td");
            var textCelda = document.createTextNode(listado[i][prop]);

            celda.appendChild(textCelda);
            fila.appendChild(celda);
        }

        //insertar celda de botones
        var celdaBtn = document.createElement("td");
        //boton editar
        var editar = document.createElement("input");
        editar.setAttribute("type", "image");
        editar.setAttribute("id", listado[i].idPersona);
        editar.setAttribute("src", "Imagenes/edit.png");
        editar.setAttribute("width", "30");
        editar.setAttribute("heigth", "30");
        editar.addEventListener("click", clickEditar, false);
        //boton eliminar
        var eliminar = document.createElement("input");
        eliminar.setAttribute("type", "image");
        eliminar.setAttribute("id", listado[i].idPersona);
        eliminar.setAttribute("src", "Imagenes/delete.png");
        eliminar.setAttribute("width", "30");
        eliminar.setAttribute("heigth", "30");
        eliminar.addEventListener("click", clickEliminar, false);

        //insertar en la celda los botones
        celdaBtn.appendChild(editar);
        celdaBtn.appendChild(eliminar);
        //insertar celda en la fila
        fila.appendChild(celdaBtn);

        //insertar fila a la tabla
        table.appendChild(fila);
    }
}

//Editar persona
function clickEditar() {

        
}

//Eliminar persona
function clickEliminar() {

    var elim = modalEliminar();

    if (elim) {
        var id = this.id;
        var llamadaEliminar = new XMLHttpRequest();
        var ruta = "https://apirestpersonasdylan.azurewebsites.net/api/Personas/" + id;
        llamadaEliminar.open("DELETE", ruta);

        llamadaEliminar.onreadystatechange = function () {

            if (llamadaEliminar.readyState == 4 && llamadaEliminar.status == 200) {

                alert("Persona borrada con exito!");
                actualizarTabla();
            }
        }
        llamadaEliminar.send();
    }
}

//Crear persona
function clickCrear() {

    var crear = document.getElementById("modalCrear");
    var btnCrear = document.getElementById("botonCrear");
    var btnCancelar = document.getElementById("botonCancelar");
    crear.style.display = "block";

    btnCrear.onclick = function () {

        var nom = document.getElementById("nombre").value;
        var ape = document.getElementById("apellidos").value;
        var fec = document.getElementById("fechaNacimiento").value;
        var dir = document.getElementById("direccion").value;
        var tfn = document.getElementById("telefono").value;
        var idD = document.getElementById("idDepartamento").value;

        var oP = new Persona(nom, ape, fec, dir, tfn, idD);
        alert("Nombre: " + oP.nombre);

        crear.style.display = "none";
    }

    btnCancelar.onclick = function () {
        crear.style.display = "none";
    }

}

//Actualizar tabla
function actualizarTabla() {

    var table = document.getElementById("tablaPersonas");
    var rowCount = table.rows.length;
    for (var i = 1; i < rowCount; i++) {
        table.deleteRow(1);
    }
    cargarLista();
}

//Modal eliminar
function modalEliminar() {

    var ret = false;
    var modal = document.getElementById("modalEliminar");
    var aceptar = document.getElementById("AceptarEliminar");
    var cancelar = document.getElementById("CancelarEliminar");
    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    aceptar.onclick = function () {
        modal.style.display = "none";
        ret = true;
    }

    cancelar.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    //window.onclick = function (event) {
    //    if (event.target == modal) {
    //        modal.style.display = "none";
    //    }
    //}



    return ret;
}

