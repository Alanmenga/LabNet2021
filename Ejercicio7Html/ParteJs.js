function mensajeLimpiar()
{
    alert("Limpiando");
    document.getElementById("input_nombre").value = "";
    document.getElementById("input_apellido").value = "";
    document.getElementById("input_edad").value = "";
    document.getElementById("input_empresa").value = "";

    var arRadioBtn = document.getElementsByName("opcion");
    for (var index = 0; index < arRadioBtn.length; index++) {
        var radBtn = arRadioBtn[index];
        radBtn.checked = false;
    }

}


function mensajeEnviar()
{
    var nombre =  document.getElementById("input_nombre").value;
    var apellido = document.getElementById("input_apellido").value;
    var edad = document.getElementById("input_edad").value;
    var empresa = document.getElementById("input_empresa").value;
    var indice = document.getElementsByName("opcion");

    if(validarDatos(nombre,apellido,edad,empresa))
    {
        for (var index = 0; index < indice.length; index++) 
        {
            var radBtn = indice[index];
            if(radBtn.checked == true && index == 0)
                alert("Nombre: "+nombre+"\nApellido: "+apellido+"\nEdad: "+edad+"\nSexo: Masculino"+"\nEmpresa: "+empresa)
            else if(radBtn.checked == true && index == 1)
                alert("Nombre: "+nombre+"\nApellido: "+apellido+"\nEdad: "+edad+"\nSexo: Femenino"+"\nEmpresa: "+empresa)
            else if(radBtn.checked == true && index == 2)
                alert("Nombre: "+nombre+"\nApellido: "+apellido+"\nEdad: "+edad+"\nSexo: No Definido"+"\nEmpresa: "+empresa)
        }
    }
}

function validarDatos(nombre,apellido,edad,empresa)
{
    if(nombre == "" || nombre == null)
    {
        alert("El nombre esta vacio o es nulo");
        //alert
        return false;
    }
    else if(apellido == "" || apellido == null)
    {
        alert("El apellido esta vacio o es nulo");
        return false;
    }
    else if(edad <=0 || edad >=100 || edad =="" || edad == null || isNaN(edad))
    {
        alert("Edad ingresada incorrecta");
        return false;
    }
    else if(empresa == "" || empresa == null)
    {
        alert("La empresa esta vacia o es nula");
        return false;
    }
    return true;
}