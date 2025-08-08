import React from "react";
import { Alert, Box } from "@mui/material";
import { FieldErrors } from "react-hook-form";

interface ErrorComponentProps {
    error?: FieldErrors | Error | string | null;
}

export const ErrorComponent: React.FC<ErrorComponentProps> = ({ error }) => {
    if (!error) return null;

    // Handle Error objects
    if (error instanceof Error) {
        return (
            <Box sx={{ mt: 2 }}>
                <Alert severity="error">{error.message}</Alert>
            </Box>
        );
    }

    // Handle string errors
    if (typeof error === "string") {
        return (
            <Box sx={{ mt: 2 }}>
                <Alert severity="error">{error}</Alert>
            </Box>
        );
    }

    // Handle FieldErrors (form validation errors)
    if (typeof error === "object" && error !== null) {
        const errorMessages = Object.values(error)
            .filter((err) => err && typeof err === "object" && "message" in err)
            .map((err) => (err as { message: string }).message)
            .filter(Boolean);

        if (errorMessages.length === 0) return null;

        return (
            <Box sx={{ mt: 2 }}>
                {errorMessages.map((message, index) => (
                    <Alert
                        key={index}
                        severity="error"
                        sx={{ mb: index < errorMessages.length - 1 ? 1 : 0 }}
                    >
                        {message}
                    </Alert>
                ))}
            </Box>
        );
    }

    return null;
};
