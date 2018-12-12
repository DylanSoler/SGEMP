window.onload = inicializaEventos;

function inicializaEventos() {

    cargarLista();
}

function cargarLista() {

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://apirestpersonasdylan.azurewebsites.net/api/Personas/");

    miLlamada.onreadystatechange = function () {

        alert(miLlamada.readyState);

        if (miLlamada.readyState < 4) {
            //document.getElementById("textoMostrar").innerHTML = "Cagrando.....";
        }
        else if (miLlamada.readyState == 4 && miLlamada.status == 200) {

            var arrayPersonas = JSON.parse(miLlamada.responseText);
            crearTabla(arrayPersonas);

        }
    }
    miLlamada.send();

}

function crearTabla(listado) {

    var table = document.getElementById("tablaPersonas");

    for (var i = 0; i < listado.length; i++)
    {
        var fila = document.createElement("tr");

        for (var prop in listado[0])
        {
            var celda = document.createElement("td");
            var textCelda = document.createTextNode(listado[i][prop]);

            celda.appendChild(textCelda);
            fila.appendChild(celda);
        }

        //boton BUENOOOOOOOOOOO
        var celdaBtn = document.createElement("td");
        var btnEditar = document.createElement("button");
        btnEditar.type = "button";
        btnEditar.setAttribute("id", listado[i].id);
        //var image = document.createElement("img");
        //image.setAttribute("src", "edit.png");
        //btnEditar.appendChild(image);
        btnEditar.addEventListener("click", function () {clickEditar}, false);                          
        celdaBtn.appendChild(btnEditar);

        fila.appendChild(celdaBtn);

        table.appendChild(fila);
    }

    function clickEditar() {

        alert('funca');
    }

}