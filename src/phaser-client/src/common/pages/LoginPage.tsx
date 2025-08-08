import React, { useState } from "react";
import {
    Container,
    Paper,
    TextField,
    Button,
    Typography,
    Box,
    Alert,
    Tabs,
    Tab,
    CircularProgress,
} from "@mui/material";
import { PokeGameUser } from "../../models/PokeGameUser";
import { SaveUserInput } from "../../models/SaveUserInput";
import { useGetUserMutation } from "../hooks/useGetUserMutation";
import { useSaveUserMutation } from "../hooks/useSaveUserMutation";

interface TabPanelProps {
    children?: React.ReactNode;
    index: number;
    value: number;
}

function TabPanel(props: TabPanelProps) {
    const { children, value, index, ...other } = props;

    return (
        <div
            role="tabpanel"
            hidden={value !== index}
            id={`login-tabpanel-${index}`}
            aria-labelledby={`login-tab-${index}`}
            {...other}
        >
            {value === index && <Box sx={{ pt: 3 }}>{children}</Box>}
        </div>
    );
}

export const LoginPage: React.FC<{
    setUser: (user: PokeGameUser) => void;
}> = ({ setUser }) => {
    const [tabValue, setTabValue] = useState(0);
    const [email, setEmail] = useState("");
    const [name, setName] = useState("");
    const [error, setError] = useState<string | null>(null);
    const [success, setSuccess] = useState<string | null>(null);

    const getUserMutation = useGetUserMutation();
    const saveUserMutation = useSaveUserMutation();

    const handleTabChange = (
        _event: React.SyntheticEvent,
        newValue: number
    ) => {
        setTabValue(newValue);
        setError(null);
        setSuccess(null);
        setEmail("");
        setName("");
    };

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);
        setSuccess(null);

        if (!email.trim()) {
            setError("Email is required");
            return;
        }

        try {
            const user = await getUserMutation.mutateAsync({
                email: email.trim(),
            });
            if (user) {
                setSuccess("Login successful!");
                setUser(user);
            } else {
                setError(
                    "User not found. Please check your email or register a new account."
                );
            }
        } catch (err) {
            setError("Login failed. Please try again.");
        }
    };

    const handleRegister = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);
        setSuccess(null);

        if (!email.trim()) {
            setError("Email is required");
            return;
        }

        if (!name.trim()) {
            setError("Name is required");
            return;
        }

        try {
            const userInput: SaveUserInput = {
                email: email.trim(),
                name: name.trim(),
            };

            const user = await saveUserMutation.mutateAsync({ userInput });
            setSuccess("Registration successful! You are now logged in.");
            setUser(user);
        } catch (err) {
            setError(
                "Registration failed. This email might already be in use."
            );
        }
    };

    const isLoading = getUserMutation.isPending || saveUserMutation.isPending;

    return (
        <Container maxWidth="sm" sx={{ mt: 8 }}>
            <Paper elevation={6} sx={{ p: 4 }}>
                <Typography
                    variant="h4"
                    component="h1"
                    align="center"
                    gutterBottom
                >
                    PokeGame
                </Typography>

                <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
                    <Tabs
                        value={tabValue}
                        onChange={handleTabChange}
                        aria-label="login register tabs"
                        variant="fullWidth"
                    >
                        <Tab
                            label="Login"
                            id="login-tab-0"
                            aria-controls="login-tabpanel-0"
                        />
                        <Tab
                            label="Register"
                            id="login-tab-1"
                            aria-controls="login-tabpanel-1"
                        />
                    </Tabs>
                </Box>

                <TabPanel value={tabValue} index={0}>
                    <Box component="form" onSubmit={handleLogin} sx={{ mt: 2 }}>
                        <TextField
                            fullWidth
                            label="Email"
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            margin="normal"
                            required
                            disabled={isLoading}
                            autoComplete="email"
                        />

                        {error && (
                            <Alert severity="error" sx={{ mt: 2 }}>
                                {error}
                            </Alert>
                        )}

                        {success && (
                            <Alert severity="success" sx={{ mt: 2 }}>
                                {success}
                            </Alert>
                        )}

                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                            disabled={isLoading}
                        >
                            {isLoading ? (
                                <CircularProgress size={24} />
                            ) : (
                                "Login"
                            )}
                        </Button>
                    </Box>
                </TabPanel>

                <TabPanel value={tabValue} index={1}>
                    <Box
                        component="form"
                        onSubmit={handleRegister}
                        sx={{ mt: 2 }}
                    >
                        <TextField
                            fullWidth
                            label="Email"
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            margin="normal"
                            required
                            disabled={isLoading}
                            autoComplete="email"
                        />

                        <TextField
                            fullWidth
                            label="Name"
                            type="text"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            margin="normal"
                            required
                            disabled={isLoading}
                            autoComplete="name"
                        />

                        {error && (
                            <Alert severity="error" sx={{ mt: 2 }}>
                                {error}
                            </Alert>
                        )}

                        {success && (
                            <Alert severity="success" sx={{ mt: 2 }}>
                                {success}
                            </Alert>
                        )}

                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                            disabled={isLoading}
                        >
                            {isLoading ? (
                                <CircularProgress size={24} />
                            ) : (
                                "Register"
                            )}
                        </Button>
                    </Box>
                </TabPanel>
            </Paper>
        </Container>
    );
};
