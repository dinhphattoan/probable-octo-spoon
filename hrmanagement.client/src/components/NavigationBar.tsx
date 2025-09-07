import { Box, Toolbar, ListItem, ListItemButton, ListItemIcon, ListItemText, Divider, List } from '@mui/material';
import { Component } from 'react';
import { Link } from 'react-router-dom';
import reactLogo from '/src/assets/react.svg';
interface NavigationBarProps {
    width: number;
}

class NavigationBar extends Component<NavigationBarProps> {
    render() {
        const { width } = this.props;
        return (
            <Box sx={{ width }}>
                <Toolbar>
                    <ListItem disablePadding sx={{ m: 0 }}>
                        <ListItemButton component={Link} to="/" sx={{ m: 0 }}>
                            <ListItemIcon sx={{ m: 0 }}>
                                <img src={reactLogo} alt="Logo" style={{ width: 32, height: 32 }} />
                            </ListItemIcon>
                            <ListItemText primary="HRManagement" sx={{ m: 0 }} />
                        </ListItemButton>
                    </ListItem>
                </Toolbar>
                <Divider />
                <List>
                    <ListItem key={'Home'} disablePadding>
                        <ListItemButton component={Link} to="/">
                            <ListItemText primary={'Home'} />
                        </ListItemButton>
                    </ListItem>
                    <ListItem key={'Manage Job'} disablePadding>
                        <ListItemButton component={Link} to="/job-post">
                            <ListItemText primary={'Manage Job'} />
                        </ListItemButton>
                    </ListItem>
                    <ListItem key={'About'} disablePadding>
                        <ListItemButton component={Link} to="/about">
                            <ListItemText primary={'About'} />
                        </ListItemButton>
                    </ListItem>
                </List>
            </Box>
        );
    }
}

export default NavigationBar;