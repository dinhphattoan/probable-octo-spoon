import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import About from './pages/About';
import NotFound from './pages/NotFound';
import { Box, Drawer } from '@mui/material';
import React from 'react';
import NavigationBar from './components/NavigationBar';
import { BASE_PAGE_LAYOUT } from './constants/BasePageLayout';
import JobPostPage from './pages/JobPostPage';
import TopAppBar from './components/TopAppBar';
import { SharedStateProvider } from './components/ShareStateProvider';
import { AppThemeProvider } from './theme/AppThemeProvider';


const drawerWidth = BASE_PAGE_LAYOUT.NAV_WIDTH_MAX;

function App() {
    // Remove destructuring from undefined 'props'
    const [mobileOpen, setMobileOpen] = React.useState(false);

    // Define container for Drawer
    const container = typeof window !== 'undefined' ? window.document.body : undefined;

    const handleDrawerClose = () => {
        setMobileOpen(false);
    };

    const handleDrawerTransitionEnd = () => { };


    return (
                <AppThemeProvider>
                    <SharedStateProvider>
                        <BrowserRouter>
                <Box
                    component="nav"
                    sx={{ width: { sm: drawerWidth }, flexShrink: { sm: 0 } }}
                    aria-label="mailbox folders"
                >
                    {/* The implementation can be swapped with js to avoid SEO duplication of links. */}
                    <Drawer
                        container={container}
                        variant="temporary"
                        open={mobileOpen}
                        onTransitionEnd={handleDrawerTransitionEnd}
                        onClose={handleDrawerClose}
                        sx={{
                            display: { xs: 'block', sm: 'none' },
                            '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
                        }}
                        slotProps={{
                            root: {
                                keepMounted: true, // Better open performance on mobile.
                            },
                        }}
                    >
                        <NavigationBar width={drawerWidth} />
                    </Drawer>
                    <Drawer
                        variant="permanent"
                        sx={{
                            display: { xs: 'none', sm: 'block' },
                            '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
                        }}
                        open
                    >
                        <NavigationBar width={drawerWidth} />
                    </Drawer>
                </Box>

                {/* Route Definitions */}
                <div className="content">
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/about" element={<About />} />
                        <Route path="/job-post" element={<JobPostPage />} />
                        <Route path="*" element={<NotFound />} />
                    </Routes>
                                </div>
                        </BrowserRouter>
                    </SharedStateProvider>
                </AppThemeProvider>


    );

}

export default App;