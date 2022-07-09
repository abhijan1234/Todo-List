import React from 'react'
import axios from "axios";

export const AxiosServicePost=(url:any,data:any,Header:any)=>{
    console.log("Came here",url,data)
    return axios.post(url,data)
}
