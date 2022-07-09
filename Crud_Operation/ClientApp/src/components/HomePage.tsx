import React, { useState } from 'react'
import "./HomePage.css"
import TextField from '@material-ui/core/TextField'
import { Button } from '@material-ui/core'
import {CreateRecordService} from '../Services/CrudServices'

const HomePage = () => {
  const [userName,SetUserName] = useState("")
  const [age,SetAge] = useState(0)

  const handleUser=(e:any)=>{
    SetUserName(e.target.value)
    console.log(e.target.value)
 }

 const handleAge=(e:any)=>{
  SetAge(e.target.value)
  console.log(e.target.value)
}

const handleSubmit=()=>{
  
  console.log("Type",typeof(Number(age)))
  const data={
    userName:userName,
    age:Number(age)
  }

  console.log("Data is:",data)
  CreateRecordService(data).then((res)=>{
    console.log("Responseeee",res)
  }).catch((error)=>{
    console.log(error)
  })
}
  return (
    <div className='MainContainer'>
      <div className='SubContainer'>
        <div className="box1">
          <div className="InputContainer">
            <div className="FlexContainer">
              <TextField label="Username" 
              fullWidth
              name='Username' 
              size='small' 
              value={userName}
              variant='outlined'
              onChange={handleUser}/>
            </div>

            <div className="FlexContainer">
              <TextField label="Age" 
              fullWidth
              name='Age' 
              size='small' 
              variant='outlined'
              value={age}
              onChange={handleAge}/>
            </div>

            <div className="flex-button">
              <Button variant='contained' color='secondary' onClick={handleSubmit}>Submit</Button>
            </div>
          </div>
        </div>
        <div className="box2">

        </div>
      </div>

    </div>
  )
}

export default HomePage
