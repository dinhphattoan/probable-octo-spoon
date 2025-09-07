import { createContext, useContext, useMemo, useState } from 'react';
import { CssBaseline, ThemeProvider, createTheme, responsiveFontSizes } from '@mui/material';
import type { PaletteMode } from '@mui/material';
import type { ReactNode } from 'react';

// Exposed context for optionally toggling color mode anywhere in the app
interface ColorModeContextValue {
  mode: PaletteMode;
  toggleColorMode: () => void;
}

const ColorModeContext = createContext<ColorModeContextValue | undefined>(undefined);
export const useColorMode = () => {
  const ctx = useContext(ColorModeContext);
  if (!ctx) throw new Error('useColorMode must be used within AppThemeProvider');
  return ctx;
};

interface AppThemeProviderProps { children: ReactNode }

// Base design tokens that are mostly mode-agnostic
const getDesignTokens = (mode: PaletteMode) => ({
  palette: {
    mode,
    primary: {
      main: '#0B5ED7',
      light: '#4d86ff',
      dark: '#063c85'
    },
    secondary: {
      main: '#FF8A00',
      light: '#ffb547',
      dark: '#b75e00'
    },
    background: {
      default: mode === 'light' ? '#f5f7fa' : '#121212',
      paper: mode === 'light' ? '#ffffff' : '#1e1e1e'
    }
  },
  shape: { borderRadius: 10 },
  typography: {
    fontFamily: 'Inter, system-ui, Avenir, Helvetica, Arial, sans-serif',
    h1: { fontSize: '2rem', fontWeight: 600 },
    h2: { fontSize: '1.5rem', fontWeight: 600 },
    h3: { fontSize: '1.25rem', fontWeight: 600 },
    // Cast textTransform to the expected union type
    button: { textTransform: 'none' as const, fontWeight: 600 }
  },
  components: {
    MuiAppBar: {
      // use undefined color so our styleOverride supplies background
      defaultProps: { elevation: 0, color: undefined },
      styleOverrides: {
        root: ({ theme }: any) => ({
          backgroundColor: theme.palette.background.paper,
          color: theme.palette.text.primary,
          borderBottom: `1px solid ${theme.palette.divider}`
        })
      }
    },
    MuiButton: {
      styleOverrides: {
        root: { borderRadius: 8 }
      }
    },
    MuiDrawer: {
      styleOverrides: {
        paper: ({ theme }: any) => ({
          backgroundImage: 'none',
          borderRight: `1px solid ${theme.palette.divider}`
        })
      }
    },
    MuiListItemButton: {
      styleOverrides: {
        root: ({ theme }: any) => ({
          borderRadius: 6,
          margin: theme.spacing(0.25, 1),
          '&.Mui-selected': {
            backgroundColor: theme.palette.action.selected,
            '&:hover': { backgroundColor: theme.palette.action.selected }
          }
        })
      }
    }
  }
});

export const AppThemeProvider = ({ children }: AppThemeProviderProps) => {
  const [mode, setMode] = useState<PaletteMode>('light');
  const toggleColorMode = () => setMode(m => (m === 'light' ? 'dark' : 'light'));

  const theme = useMemo(() => responsiveFontSizes(createTheme(getDesignTokens(mode) as any)), [mode]);

  return (
    <ColorModeContext.Provider value={{ mode, toggleColorMode }}>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        {children}
      </ThemeProvider>
    </ColorModeContext.Provider>
  );
};
