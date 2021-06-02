
let producto = {}

let txtMedicamento = document.getElementById('txtMedicamento');
let txtStock = document.getElementById('txtStock');
let txtFecha = document.getElementById('txtFecha');
let txtPrecio = document.getElementById('txtPrecio');
let txtCantidad = document.getElementById('txtCantidad');
let txtDescuento = document.getElementById('txtDescuento');


let btnBuscar = document.getElementById('btnBuscar').addEventListener('click', function (event) {
    event.preventDefault();
    let txtBuscarProducto = document.getElementById('txtBuscarProducto');
    if (txtBuscarProducto.value != null || txtBuscarProducto.value != "") {
        Swal.fire({
            timerProgressBar: true,
            showCancelButton: false,
            showConfirmButton: false,
            willOpen: () => {
                Swal.showLoading()
                fetch(`/Productos/FindMedicamentoByName?nameMedicamento=${txtBuscarProducto.value}`).then(response => response.json())
                    .then(res => producto = res)
                    .catch(err => console.log(err));
                if (producto != null) {
                    showResult(producto)
                }
                console.log(producto);
                Swal.close()
            }
        })
    } else {
        Swal.fire({
            icon: 'error',
            text: 'Debe Ingresar el nombre de un medicamento',
        });
        txtBuscarProducto.focus();
    }
    
   
    return;
})


function showResult(data) {
    txtMedicamento.value = data.nombre
    txtStock.value = data.cantidad
    txtPrecio.value = data.costoPublico
}