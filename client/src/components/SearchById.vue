<template>
    <div class="searchById">
        <h2>BUSQUE EL CONTRATO SEGUN SU ID</h2>
        <form action="" class="formId">
            <label for="searchById">ID: </label>
            <input type="text" placeholder="Ingrese el Id..." v-model="id" class="input">
            <button type="button" class="btn btn-primary" @click="searchById(id)"> Buscar </button>
        </form>
        <SearchResultsVue v-if="this.response" :response="response" :pedido="pedido" :id="id" />
    </div>
</template>

<script>
import axios from 'axios';
import SearchResultsVue from './SearchResults.vue';

export default {
    data() {
        return {
            id: null,
            URL: "https://localhost:7034/api/Contracts/",
            response: null,
            pedido: []
        }
    },
    methods: {
        async searchById(id) {
            try {
                const { data } = await axios.get(this.URL + `${id}`)

                this.response = data;

                for (let i = 0; i < data.contractItems.length; i++) {
                    var linea = {}

                    linea.cantidad = data.cantidadEgresados;
                    linea.articulo = data.contractItems[i].item.nombre;
                    linea.precioUnitario = data.contractItems[i].item.precio;
                    linea.total = data.contractItems[i].item.precio * data.cantidadEgresados;

                    this.pedido.push(linea);
                }

            } catch (error) {
                console.log(error);
                alert('Error en la peticion')
                return
            }
        }
    },
    components: {
        SearchResultsVue
    }
}
</script>

<style scoped>
.searchById {
    margin: 2rem;
}

.searchById h2 {
    text-align: center;
}

.formId {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 1rem;
}

.input {
    border-radius: 0.3rem;
    border: none;
}
</style>