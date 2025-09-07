import React from 'react';
import { CircularProgress } from '@mui/material';

const LoadingIndicator: React.FC = () => (
    <div style={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '200px',
        width: '100%',
    }}>
        <CircularProgress />
    </div>
);

export default LoadingIndicator;