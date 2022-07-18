export enum MenuLinkRu {
    HOME = 'Главная',
    CATALOG = 'Каталог',
    REVIEWS = 'Отзывы',
}

export enum MenuLinkEn {
    HOME = '/',
    CATALOG = '/catalog',
    REVIEWS = '/reviews',
}

export type Menu = {
    name: MenuLinkRu.HOME | MenuLinkRu.CATALOG | MenuLinkRu.REVIEWS;
    link: MenuLinkEn.HOME | MenuLinkEn.CATALOG | MenuLinkEn.REVIEWS;
};

export const headerMenu: Menu[] = [
    {
        name: MenuLinkRu.HOME,
        link: MenuLinkEn.HOME,
    },
    {
        name: MenuLinkRu.CATALOG,
        link: MenuLinkEn.CATALOG,
    },
    {
        name: MenuLinkRu.REVIEWS,
        link: MenuLinkEn.REVIEWS,
    },
];