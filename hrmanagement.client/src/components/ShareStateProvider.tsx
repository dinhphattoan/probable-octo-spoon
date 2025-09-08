import React, { createContext, useState, useContext } from 'react';

const SharedStateContext = createContext<any>(null);

export const SharedStateProvider = ({ children }: { children: React.ReactNode }) => {
  const [sharedValue, setSharedValue] = useState(false);
  const [isMobileOpen, setIsMobileOpen] = useState(false);
  return (
    <SharedStateContext.Provider value={{ sharedValue, setSharedValue, isMobileOpen, setIsMobileOpen }}>
      {children}
    </SharedStateContext.Provider>
  );
};

export const useSharedState = () => useContext(SharedStateContext);