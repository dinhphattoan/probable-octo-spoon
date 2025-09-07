import { Box, Button, Modal } from '@mui/material';
import React, { Component, useState } from 'react';
const style = {
    position: 'absolute' as const,
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    boxShadow: 24,
    p: 4,
};
interface NewJobPostModalProps {
    open: boolean;
    onClose: () => void;
}

const NewJobPostModal: React.FC<NewJobPostModalProps> = ({ open, onClose }) => {
    return (
        <Modal
            open={open}
            onClose={onClose}
            aria-labelledby="modal-job-post-title"
            aria-describedby="modal-job-post-description"
        >
            <Box sx={style}>
                <h2 id="modal-job-post-title">Create New Job Post</h2>
                <p id="modal-job-post-description">
                    {/* Add your job post form or content here */}
                    This is a placeholder for the job post form.
                </p>
                <Button onClick={onClose}>Close</Button>
            </Box>
        </Modal>
    );
};

export default NewJobPostModal;