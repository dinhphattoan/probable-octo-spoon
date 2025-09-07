import React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import TopAppBar from '../components/TopAppBar';

const JobPostPage: React.FC = () => {

    return (
        <Box>
            <TopAppBar children={
                <>
                    <Box sx={{ flexGrow: 1 }}>
                    </Box>
                    <Box>
                        <Button variant="contained" href="/job-post">
                            New Job Post
                        </Button>
                    </Box>
                </>
            } />
        </Box>
    );
}

export default JobPostPage;