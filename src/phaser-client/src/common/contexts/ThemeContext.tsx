import React, { createContext, useContext, ReactNode } from "react";
import { createTheme, ThemeProvider, Theme } from "@mui/material/styles";
import { CssBaseline } from "@mui/material";

const darkTheme = createTheme({
    palette: {
        mode: "dark",
        primary: {
            main: "#90caf9",
        },
        secondary: {
            main: "#f48fb1",
        },
        background: {
            default: "#121212",
            paper: "#1e1e1e",
        },
        text: {
            primary: "#ffffff",
            secondary: "#b0b0b0",
        },
    },
    components: {
        MuiTextField: {
            styleOverrides: {
                root: {
                    "& .MuiOutlinedInput-root": {
                        "& fieldset": {
                            borderColor: "#555",
                        },
                        "&:hover fieldset": {
                            borderColor: "#90caf9",
                        },
                    },
                },
            },
        },
        MuiButton: {
            styleOverrides: {
                root: {
                    textTransform: "none",
                    borderRadius: 8,
                },
            },
        },
    },
});

const ThemeContext = createContext<Theme>(darkTheme);

export const useTheme = (): Theme => {
    const context = useContext(ThemeContext);
    if (!context) {
        throw new Error("useTheme must be used within a PokeGameThemeProvider");
    }
    return context;
};

interface PokeGameThemeProviderProps {
    children: ReactNode;
}

export const PokeGameThemeProvider: React.FC<PokeGameThemeProviderProps> = ({
    children,
}) => {
    return (
        <ThemeContext.Provider value={darkTheme}>
            <ThemeProvider theme={darkTheme}>
                <CssBaseline />
                {children}
            </ThemeProvider>
        </ThemeContext.Provider>
    );
};
