import React from 'react'
import {Configuration} from "./../Configuration/Configuration"
import {AxiosServicePost} from './AxiosService'

  
export const CreateRecordService=(data:any)=>
  {
    console.log(data,Configuration.CreateRecord)
    return AxiosServicePost(Configuration.CreateRecord,data,false)
  }


