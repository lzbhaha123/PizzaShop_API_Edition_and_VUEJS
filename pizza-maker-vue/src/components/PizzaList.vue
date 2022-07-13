<template>
    <div>
        <div class="pizza_list">
            <div v-for="p in pizzas">
                <el-image fit="fill" :src="p.pizza.img" />
                <p>{{p.pizza.name}}</p>
                <div>
                    <span v-for="(t,i) in p.pizza.toppings"> {{t.name}} </span>
                </div>
                <div>Price:${{p.pizza.price}}</div>
                <el-input-number :min="0" v-model="p.pizza.total" :step="1" />

            </div>
        </div>
        <el-drawer
            size="80%"
            v-model="trolleyDrawer"
            title="My trolley"
            direction="btt"
        >


            <div v-for="(p,i) in pizzas">
                <div class="trolley_item" v-if="p.pizza.total>0">
                    <div>{{p.pizza.name}}</div>
                    <div>Count:{{p.pizza.total}}&nbsp;&nbsp;Price:${{p.pizza.price * p.pizza.total }}</div>
                </div>
            </div>
            <div>
                Total:${{totalPrice}}
            </div>
        </el-drawer>
        <el-button @click="trolleyDrawer = true" class="trolley_btn"  type="primary">My trolley</el-button>
    </div>
</template>
<script lang="ts">

import {defineComponent } from 'vue'
import { ElButton,ElImage,ElInputNumber } from 'element-plus'
import axios from 'axios';
export default defineComponent ({
    name:"PizzaList",
    components:{ElButton,ElImage,ElInputNumber  },
    /*
    props:{
        pizzas:['Hawaii Pizza','Cheese Pizza']
    }*/
    data(){
        return{
            pizzas:[],
            trolleyDrawer:false,
            totalPrice:0
        }
    },
    watch:{
        trolleyDrawer(){
            this.totalPrice = 0
            for(var i=0;i<this.pizzas.length;i++){
                this.totalPrice+= this.pizzas[i].pizza.total * this.pizzas[i].pizza.price
            }
            this.$forceUpdate()
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
            this.pizzas = response.data
        })  
        
    },
    methods:{
        
        myTrolley(){

        }
    },
    computed:{
        
    }
})

</script>
<style scoped>

</style>