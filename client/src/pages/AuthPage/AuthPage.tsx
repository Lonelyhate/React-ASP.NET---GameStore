import axios from 'axios'
import React, { useEffect } from 'react'

const reg = {
    login: "string",
    password: "string",
    passwordConfrim: "string"
}

const AuthPage = () => {
    useEffect(() => {
        axios.post("https://localhost:7192/api/Account/register", reg)
    }, [])
  return (
    <div>input</div>
  )
}

export default AuthPage