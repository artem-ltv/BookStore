"use client";

import Button from "antd/es/button/button";
import { useEffect, useState } from "react";
import { Books } from "../components/Books";
import { getAllBooks } from "../services/books";

export default function BooksPage(){
    const [books, setBooks] = useState<Book[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const getBooks = async () => {
            const books = await getAllBooks();
            setLoading(false);
            setBooks(books);
        };

        getBooks();
    }, [])

    return (
        <div>
            <Button>Добавить книгу</Button>

            <Books books={books} />
        </div>
    )
}