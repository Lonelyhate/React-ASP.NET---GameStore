import React, { FC } from 'react'
import Logo from '../Logo/Logo'
import HeaderMenu from './HeaderMenu/HeaderMenu'
import HeaderProfile from './HeaderProfile/HeaderProfile'
import './Header.scss';

const Header: FC = () => {
  return (
    <header className="header">
        <div className="header__container container">
            <Logo/>
            <HeaderMenu/>
            <HeaderProfile/>
        </div>
    </header>
  )
}

export default Header