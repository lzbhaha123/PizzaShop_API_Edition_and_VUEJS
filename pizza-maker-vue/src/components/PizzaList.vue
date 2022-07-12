<template>
    <div>
        <p v-for="p in pizzas">{{p.pizza.name}}</p>

        <el-row>
            <el-col
            v-for="(o, p) in pizzas"
            :key="p"
            :span="10"
            :offset="1"
            >
                <el-card :body-style="{ padding: '0px' }">
                    <img
                    src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
                    class="image"
                    />
                    <div style="padding: 14px">
                    <span>{{o.pizza.name}}</span>
                    <div class="bottom">
                        <p v-for="t in o.pizza.toppings"> {{t.name}} </p>
                    </div>
                    </div>
                </el-card>
            </el-col>
        </el-row>



        <el-button>I am ElButton</el-button>
    </div>
</template>
<script lang="ts">

import {defineComponent } from 'vue'
import {ElRow,ElCol, ElButton,ElCard } from 'element-plus'
import axios from "axios";
export default defineComponent ({
    name:"PizzaList",
    components:{ElRow,ElCol,ElButton,ElCard },
    /*
    props:{
        pizzas:['Hawaii Pizza','Cheese Pizza']
    }*/
    data(){
        return{
            pizzas:[]
        }
    },
    mounted() {
        axios({
            method: 'GET',
            url: 'https://localhost:7242/api/Pizzas',
            headers: { 
                'Content-Type': 'application/json'
            },
        }).then(response => {
            this.pizzas = response.data ,
            console.log(this.pizzas[0].pizza.id)
        })  
       
       /*
(function (){
            _this.data.pizzas = response.data
            console.log(_this.data.pizzas[0])
        })

       */
        
    },
})

</script>