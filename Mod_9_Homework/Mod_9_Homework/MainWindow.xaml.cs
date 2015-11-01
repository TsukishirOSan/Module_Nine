using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mod_9_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// // I changed the field city to a field birthdate in MainWindow.g.i.cs and changed all the labels and text fields regarding city with Birthdate
    /// //(i.e. lblBirthdate txtBirthdate etc....) I wanted to use a field that wasn't directly a string. I hope you won't mind!! 
    /// </summary>
    public partial class MainWindow : Window
    {
        // arguments needed without instanciation outside of any class and Main
        // create a list of objects of type Student
        public List<Student> students { get; set; }
        // integer used as an index to acces fields of objects
        public static int i = 0;

        public MainWindow()
        {
            this.students = new List<Student>();
            InitializeComponent();
            btnCreateStudent.Click += clickOnBtn_CreateStudent;
            btnNext.Click += clickOnbtn_Next;
            btnPrevious.Click += clickOnbtn_Prev;
        }

        public void clickOnBtn_CreateStudent(object sender, RoutedEventArgs rea)
        {
            // Instanciate a student Student
            Student student = new Student("","","");
            // Add that student to the list of student
            students.Add(student);
            // assign values to Student fields
            this.students[i].First = txtFirstName.Text;
            this.students[i].Last = txtLastName.Text;
            // DateTime to string object to display the birthdate
            this.students[i].Birthdate = new DateTime(1982, 3, 6).ToString("dd/mm/yyyy");
            this.students[i].Birthdate = txtBirthdate.Text;

            // clear the contents of the control instead of assigning the Text property an empty string.
            txtFirstName.Clear();
            txtLastName.Clear();
            txtBirthdate.Clear();
            // next field of the list students
            i++;
        }
        // handles the click on the button next event
        public void clickOnbtn_Next(object sender, RoutedEventArgs rea)
        {
            // if the index of the List of objext Student students is greater or equal to the Student object counter CountStuds(-1: 0-indexed)
            if(i >= Student.CountStuds - 1)
            {
                // reset i
                i = 0;
            }
            else
            {
                //everything ok, increment
                i++;
            }
            // assign values using Student object fields.
            txtFirstName.Text = students[i].First;
            txtLastName.Text = students[i].Last;
            txtBirthdate.Text = students[i].Birthdate;
        }

        // handles the click on the button prev event
        public void clickOnbtn_Prev(object sender, RoutedEventArgs rea)
        {
            // if nothing in the list of object Student
            if( i <= 0)
            {
                // assign to index the counter of object Student -1 (0-indexed)
                i = Student.CountStuds - 1;
            }
            else
            {
                // decrement the list of object Student's index
                i--;
            }
            // assign values using Student object fields.
            txtFirstName.Text = students[i].First;
            txtLastName.Text = students[i].Last;
            txtBirthdate.Text = students[i].Birthdate;
        }

        #region dedicated to the class Student
        public class Student
        {
            //create and initialize the number of students counter
            private static int count_studs = 0;
            public static int CountStuds
            {
                get
                {
                    return count_studs;
                }
                set
                {
                    count_studs = value;
                }
            }
            
            // this is the type of the encapsulated getter setter related to the first name
            private string first;
            public string First
            {
                get
                {
                    return first;
                }
                set
                {
                    if (value != null)
                        first = value;
                }
            }

            // this is the type of the encapsulated getter setter related to the last name same for below
            private string last;
            public string Last
            {
                get
                {
                    return last;
                }
                set
                {
                    if (value != null)
                        last = value;
                }
            }

            private string birthdate;
            public string Birthdate
            {
                get
                {
                    return birthdate;
                }

                set
                {
                    if (value != null)
                        birthdate = value;
                }
            }
            public Student(string first, string last, string Birthdate)
            {
                this.First = First;
                this.Last = last;
                this.Birthdate = birthdate;
                // increment the number of Student instanciated
                CountStuds++;
            }
        }
        #endregion
    }
}