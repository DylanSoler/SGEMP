
window.onload = inicializaEventos;

function inicializaEventos() {

    cargarLista();
    document.getElementById("create").addEventListener("click", clickCrear, false);
}



// Hace una peticion get a la api y ejecuta la funcion crearTabla a partir del resultado obtenido (GET)
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


//Rellena el modal para crear persona y ejecuta la funcion de insercion
function clickCrear() {

    var crear = document.getElementById("modalCrear");
    var btnCrear = document.getElementById("botonCrear");
    var btnCancelar = document.getElementById("botonCancelar");
    crear.style.display = "block";

    btnCrear.onclick = function () {

        var idP = 1;
        var nomb = document.getElementById("nombre").value;
        var apell = document.getElementById("apellidos").value;
        var fechaN = document.getElementById("fechaNacimiento").value;
        var dir = document.getElementById("direccion").value;
        var tel = document.getElementById("telefono").value;
        var idDep = document.getElementById("idDepartamento").value;

        //var oP = new Persona(idPersona, nombre, apellidos, fechaNacimiento, direccion, telefono, idDepartamento);
        var oP = new Object();
        oP.idPersona = idP;
        oP.nombre = nomb;
        oP.apellidos = apell;
        oP.fechaNacimiento = fechaN;
        oP.direccion = dir;
        oP.telefono = tel;
        oP.idDepartamento = idDep;

        insertarPersona(oP);
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

//Inserta una persona (POST)
function insertarPersona(pers) {

    var llamadaInsertar = new XMLHttpRequest();
    var ruta = "https://apirestpersonasdylan.azurewebsites.net/api/Personas/";
    llamadaInsertar.open('POST', ruta, false);
    llamadaInsertar.setRequestHeader('Content-type', 'application/json');

    llamadaInsertar.onreadystatechange = function () {

        if (llamadaInsertar.readyState == 4 && llamadaInsertar.status == 200) {

            alert("Persona creada con exito!");
            crear.style.display = "none";
            actualizarTabla();
        }
    }

    llamadaInsertar.send(JSON.stringify(pers));
}


//Eliminar una persona (DELETE)
function clickEliminar() {

    //modal
    var id = this.id;
    var modal = document.getElementById("modalEliminar");
    var aceptar = document.getElementById("AceptarEliminar");
    var cancelar = document.getElementById("CancelarEliminar");
    modal.style.display = "block";

    //Si acepta
    aceptar.onclick = function () {
        modal.style.display = "none";

        //eliminar
        var llamadaEliminar = new XMLHttpRequest();
        var ruta = "https://apirestpersonasdylan.azurewebsites.net/api/Personas/" + id;
        llamadaEliminar.open("DELETE", ruta);

        llamadaEliminar.onreadystatechange = function () {

           if (llamadaEliminar.readyState == 4 && llamadaEliminar.status == 200) {

              //actualizar
              actualizarTabla();
              alert("Persona borrada con exito!");
            }
        }
        llamadaEliminar.send();
    }

    //Si cancela
    cancelar.onclick = function () {
        modal.style.display = "none";
    }
}

//Actualiza una persona (PUT)
function clickEditar() {

    var editar = document.getElementById("modalEditar");
    var btnConfirmar = document.getElementById("botonConfirmar");
    var btnCancelar = document.getElementById("botonCancelarEditar");
    editar.style.display = "block";

    var pers = consultarPersona(this.id);

    var id = document.getElementById("idPersona");
    id.setAttribute("value", pers.idPersona);
    document.getElementById("nombreE").setAttribute("value", pers.nombre);
    document.getElementById("apellidosE").setAttribute("value", pers.apellidos);
    document.getElementById("direccionE").setAttribute("value", pers.direccion);
    document.getElementById("telefonoE").setAttribute("value", pers.telefono);
    var porque2 = pers.fechaNacimiento.substr(0, 4)+"-"+pers.fechaNacimiento.substr(5, 2)+"-"+pers.fechaNacimiento.substr(8, 2);
    document.getElementById("fechaNacimientoE").setAttribute("value", porque2);
    document.getElementById("idDepartamentoE").setAttribute("value", pers.idDepartamento);

    btnConfirmar.onclick = function () {
        id.focus();
        var per = new Object();
        per = recogerDatosPersonaModalCrear();
        var miLlamada = new XMLHttpRequest();
        var ruta = "https://apirestpersonasdylan.azurewebsites.net/api/Personas/" + id.getAttribute("value");
        miLlamada.open("PUT", ruta);
        miLlamada.setRequestHeader('Content-type', 'application/json');

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {

            //actualizar
            alert("Persona editada con exito!");
            editar.style.display = "none";
            actualizarTabla();
        }

        miLlamada.send(JSON.stringify(per));
    }

    btnCancelar.onclick = function () {

        editar.style.display = "none";
    }
}


//Hace una peticion get de una persona segun id (GET{ID})
function consultarPersona(id) {

    var person;
    var miLlamada = new XMLHttpRequest();
    var ruta = "https://apirestpersonasdylan.azurewebsites.net/api/Personas/" + id;
    miLlamada.open("GET", ruta, false);

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {

            person = JSON.parse(miLlamada.responseText);

        }
    }

    miLlamada.send();

    return person;
}

//El nombre es bastante autodocumentado
function recogerDatosPersonaModalCrear() {

    var persona = new Object();
    persona.idPersona = document.getElementById("idPersona").value;
    persona.nombre = document.getElementById("nombreE").value;
    persona.apellidos = document.getElementById("apellidosE").value;
    persona.direccion = document.getElementById("direccionE").value;
    persona.telefono = document.getElementById("telefonoE").value;
    persona.fechaNacimiento = document.getElementById("fechaNacimientoE").value;
    persona.idDepartamento = document.getElementById("idDepartamentoE").value;

    return persona;

}