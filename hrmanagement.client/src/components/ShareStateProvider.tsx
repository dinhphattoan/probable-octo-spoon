import React, { createContext, useState, useContext } from 'react';

const SharedStateContext = createContext<any>(null);

export const SharedStateProvider = ({ children }: { children: React.ReactNode }) => {
  const [sharedValue, setSharedValue] = useState(false);
  return (
    <SharedStateContext.Provider value={{ sharedValue, setSharedValue }}>
      {children}
    </SharedStateContext.Provider>
  );
};

export const useSharedState = () => useContext(SharedStateContext);