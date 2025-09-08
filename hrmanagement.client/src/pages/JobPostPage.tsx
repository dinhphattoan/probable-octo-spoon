import React, { useState } from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import TopAppBar from '../components/TopAppBar';
import { Accordion, AccordionDetails, AccordionSummary, Typography } from '@mui/material';
import NewJobPostModal from '../Modals/NewJobPostModal';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';

const JobPostPage: React.FC = () => {
    const [open, setOpen] = useState(false);

    function handleClose(): void {
        setOpen(false);
    }

    function handleOpen(): void {
        setOpen(true);
    }

    return (
        <Box>
            <TopAppBar children={
                <>
                    <Box sx={{ flexGrow: 1 }}>
                    </Box>
                    <Box>
                        <Button variant="contained" onClick={handleOpen}>
                            New Job Post
                        </Button>
                    </Box>
                </>
            } />
            <NewJobPostModal open={open} onClose={handleClose} />
            <Accordion
                >
                <AccordionSummary
                    expandIcon={<ExpandMoreIcon />}
                    
                    aria-controls="panel1-content"
                    id="panel1-header"
                >
                    <Typography fontWeight={"bold"} component="span">Active Job Posts</Typography>
                </AccordionSummary>
                <AccordionDetails>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
                    malesuada lacus ex, sit amet blandit leo lobortis eget.
                </AccordionDetails>
            </Accordion>
        </Box>
    );
}

export default JobPostPage;