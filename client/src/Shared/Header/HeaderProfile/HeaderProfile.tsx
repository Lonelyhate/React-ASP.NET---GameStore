import React, { FC } from 'react';
import './HeaderProfile.scss';
import ProfileImg from '../../../asstes/img/profile.svg';

const HeaderProfile: FC = () => {
    return (
        <div className="header-profile">
            <img src={ProfileImg} alt="" />
        </div>
    );
};

export default HeaderProfile;
