<template>
    <div class="resultados">
        <h1>CONTRATO N° {{ id }}</h1>
        <div class="datosContrato">
            <p><strong>Codigo de curso:</strong> {{ response.courseCode }}</p>
            <p><strong>Fecha de alta:</strong> {{ response.fechaAlta.substring(0, 10) }}</p>
            <p><strong>Colegio:</strong> {{ response.colegioNombre }}</p>
            <p><strong>Nivel:</strong> {{ response.colegioNivel }}</p>
            <p><strong>Curso:</strong> {{ response.colegioCurso }}</p>
            <p><strong>Localidad:</strong> {{ response.colegioLocalidad }}</p>
        </div>
        <h3>Pedido:</h3>
        <div class="pedidos">
            <div class="tabla">
                <div class="titulos">
                    <div class="item">Cantidad</div>
                    <div class="item">Artículo</div>
                    <div class="item">Precio Unitario</div>
                    <div class="item">Total</div>
                </div>
                <div class="contenido">
                    <div class="filas" v-for="(linea, index) in pedido" :key="index">
                        <div class="fila">{{ linea.cantidad }}</div>
                        <div class="fila">{{ linea.articulo }}</div>
                        <div class="fila">${{ linea.precioUnitario.toFixed(2) }}</div>
                        <div class="fila">${{ linea.total.toFixed(2) }}</div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <h4 id="total"><strong>TOTAL:</strong><span class="grande">${{ response.total }}</span></h4>
            <h4 id="fechaEntrega"><strong>FECHA ENTREGA:</strong><span class="grande">{{ response.fechaEntrega.substring(0,
                10) }}</span></h4>
        </div>
    </div>
</template>

<script>

export default {
    props: {
        response: {
            type: Object,
            default: null
        },
        pedido: {
            type: Array,
            default: null
        },
        id: {
            type: Number,
            default: null
        }
    }
}
</script>

<style scoped>
p {
    font-size: 1.1rem;
}

.datosContrato {
    margin: 1rem 0rem;
}

.resultados {
    display: flex;
    flex-direction: column;
    padding: 1.2rem;
    background-color: ghostwhite;
    margin-top: 1.2rem;
}

h1 {
    text-align: center;
    margin: 1.4rem;
}

#total {
    display: flex;
    justify-content: space-around;
    align-items: center;
    padding: 1rem;
}

.grande {
    font-size: 2.2rem;
}

#fechaEntrega {
    display: flex;
    justify-content: space-around;
    align-items: center;
    padding: 1rem;
}

.tabla {
    display: flex;
    flex-direction: column;
    width: 100%;
    border: 1px solid grey;
}

.titulos,
.filas {
    display: flex;
    justify-content: space-between;
    padding: 0.5rem;
}

.titulos {
    background-color: rgb(153, 153, 253);
    font-weight: bold;
}

.contenido {
    width: 100%;
}

.fila {
    flex: 1;
    text-align: center;
    padding: 0.5rem 0;
}
</style>