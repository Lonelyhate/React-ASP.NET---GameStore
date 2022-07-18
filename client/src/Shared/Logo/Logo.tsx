import React, { FC } from 'react';
import { Link } from 'react-router-dom';
import './Logo.scss';
import { IoGameController } from 'react-icons/io5';

const Logo: FC = () => {
    return (
        <Link className="logo" to="/">
            <IoGameController className='logo__img' />
            <h6 className='logo__text' >GameStore</h6>
        </Link>
    );
};

export default Logo;
