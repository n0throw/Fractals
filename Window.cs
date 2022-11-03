using Fractals.LoggerCore;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Fractals;

internal class Window
{
    private delegate void WindowClosed(Exception? ex);
    private event WindowClosed? windowClosed;
    private readonly Logger logger;

    private readonly RenderWindow window;

    internal Window(uint width = 800u, uint height = 800u)
    {
        logger = new();
        window = new RenderWindow(
            mode: new VideoMode(width, height),
            title: "Fractals");

        SetSettings();
        SetEvents();
        Resize(width, height);

    }

    internal void Start()
    {
        while (window.IsOpen)
        {
            window.DispatchEvents();

            window.Clear(Color.Black);
            // Draw current fractal
            //window.Draw(triangleSprite);
            window.Display();
        }
    }

    private void SetSettings()
    {
        window.SetFramerateLimit(60);
        window.SetVerticalSyncEnabled(true);
    }

    private void SetEvents()
    {
        window.Closed += Closed;
        window.KeyPressed += KeyPressed;
        windowClosed += logger.Close;
    }

    private void Resize(uint width, uint height)
    {
        if (VideoMode.DesktopMode.Width <= width
            || VideoMode.DesktopMode.Height <= height)
        {
            uint curWidth = width / VideoMode.DesktopMode.Width;
            uint curHeight = height / VideoMode.DesktopMode.Height;

            if (curHeight > curWidth)
                Zoom(curHeight);
            else
                Zoom(curWidth);
        }
    }

    private void KeyPressed(object? sender, KeyEventArgs e)
    {
        switch (e.Code)
        {
            case Keyboard.Key.Escape:
                window.Close();
                break;
            case Keyboard.Key.Add:
                Zoom(1.5f);
                break;
            case Keyboard.Key.Subtract:
                Zoom(.75f);
                break;
            case Keyboard.Key.Up:
                Move(Direction.Up);
                break;
            case Keyboard.Key.Right:
                Move(Direction.Right);
                break;
            case Keyboard.Key.Down:
                Move(Direction.Down);
                break;
            case Keyboard.Key.Left:
                Move(Direction.Left);
                break;
            default:
                logger.Add(
                    $"На эту клавишу нет действий:{nameof(e.Code)}({e.Code})",
                    LogType.Warning);
                break;
        }
    }

    private void Move(Direction dic)
    {
        View view = window.GetView();

        view.Move(dic switch
        {
            Direction.Up
                => new Vector2f(0f, -50f),
            Direction.Down
                => new Vector2f(0f, 50f),
            Direction.Left
                => new Vector2f(-50f, 0f),
            Direction.Right
                => new Vector2f(50f, 0f),
            _ => new Vector2f(0, 0)
        });

        window.SetView(view);
    }

    private void Zoom(float coef)
    {
        View view = window.GetView();
        view.Zoom(coef);
        window.SetView(view);
    }

    private void Closed(object? sender, EventArgs e)
    {
        windowClosed?.Invoke(null);
        window.Close();
    }
}
