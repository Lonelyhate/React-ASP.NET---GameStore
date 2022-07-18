import React, { FC } from 'react'
import { Link } from 'react-router-dom'
import { headerMenu } from '../../../types/Menu'
import './HeaderMenu.scss'

const HeaderMenu: FC = () => {
  return (
    <nav className="menu">
        <ul className="menu__list">
            {headerMenu.map(item => (
                <li key={item.link} className="menu__item">
                    <Link className='menu__link' to={item.link} >{item.name}</Link>
                </li>
            ))}
        </ul>
    </nav>
  )
}

export default HeaderMenu