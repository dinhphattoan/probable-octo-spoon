import { AppBar, Toolbar } from '@mui/material';
import React from 'react';
import { BASE_PAGE_LAYOUT } from '../constants/BasePageLayout';

const drawerWidth = BASE_PAGE_LAYOUT.NAV_WIDTH_MAX;
interface TopAppBarProps {
    children?: React.ReactNode | React.ReactNode[];
}

const TopAppBar: React.FC<TopAppBarProps> = ({ children }) => {
    return (
        <AppBar
            position="fixed"
            sx={{
                width: { sm: `calc(100% - ${drawerWidth}px)` },
                ml: { sm: `${drawerWidth}px` },
            }}
        >
            <Toolbar>
                {children}
            </Toolbar>
        </AppBar>
    );
};

export default TopAppBar;