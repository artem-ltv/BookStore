export interface BookRequest{
    title: string;
    description: string;
    price: number
}

export const getAllBooks = async() => {
    const response = await fetch("https://localhost:44379/Books");

    return response.json();
}

export const createBook = async(request: BookRequest) => {
    await fetch("https://localhost:44379/Books", {
        method: "POST",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(request),
    });
}

export const updateBook = async (id: string, request: BookRequest) => {
    await fetch(`https://localhost:44379/Books/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(request),
    });
}

export const deleteBook = async (id: string) => {
    await fetch(`https://localhost:44379/Books/${id}`, {
        method: "DELETE",
    });
}